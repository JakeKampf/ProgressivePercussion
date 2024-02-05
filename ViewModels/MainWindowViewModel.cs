
using ProgressivePercussion.Commands;
using ProgressivePercussion.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace ProgressivePercussion.ViewModels
{
   public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
   {
      private IExerciseGenerator _exerciseGenerator;
      private IExercise _exercise;
      private int _exerciseIndex = 0;

      public event PropertyChangedEventHandler PropertyChanged;

      public MainWindowViewModel()
      {
         _exerciseGenerator = new ExerciseGenerator(new RudimentReader());
         _exercise = _exerciseGenerator.GenerateExercise();

         _currentRudimentImage = _exercise.RudimentCollection[_exerciseIndex].RudimentImage.ToString();
         _currentRudimentName = _exercise.RudimentCollection[_exerciseIndex].RudimentName;

         NextExerciseCommand = new RelayCommand(ExecuteNextExerciseCommand, CanExecuteNextExerciseCommand);
         PreviousExerciseCommand = new RelayCommand(ExecutePreviousExerciseCommand, CanExecutePreviousExerciseCommand);

         IncreaseTempoCommand = new RelayCommand(ExecuteIncreaseTempoCommand, CanExecuteIncreaseTempoCommand);
         DecreaseTempoCommand = new RelayCommand(ExecuteDecreaseTempoCommand, CanExecuteDecreaseTempoCommand);
      }

      public string ExerciseName => _exercise.ExerciseName;

      private string _exerciseTempo;
      public string ExerciseTempo
      {
         get => _exercise.ExerciseTempo.ToString();
         set
         {
            if (_exerciseTempo != value)
            {
               _exerciseTempo = value;
               OnPropertyChanged(nameof(ExerciseTempo));
            }
         }
      }
      public string NumberOfMeasures => "Measures: " + _exercise.NumberOfMeasures;

      public string IncreaseTempoLabel => "+";
      public string DecreaseTempoLabel => "-";


      private string _currentRudimentImage;
      public string CurrentRudimentImage
      {
         get => _currentRudimentImage;
         set
         {
            if (_currentRudimentImage != value)
            {
               _currentRudimentImage = value;
               OnPropertyChanged(nameof(CurrentRudimentImage));
            }
         }
      }

      private string _currentRudimentName;
      public string CurrentRudimentName
      {
         get => _currentRudimentName;
         set
         {
            if (_currentRudimentName != value)
            {
               _currentRudimentName = value;
               OnPropertyChanged(nameof(CurrentRudimentName));
            }
         }
      }

      public ICommand PreviousExerciseCommand { get; }
      private void ExecutePreviousExerciseCommand(object parameter)
      {
         _exerciseIndex--;
         CurrentRudimentName = _exercise.RudimentCollection[_exerciseIndex].RudimentName;
         CurrentRudimentImage = _exercise.RudimentCollection[_exerciseIndex].RudimentImage.ToString();
      }

      public ICommand NextExerciseCommand { get; }
      private void ExecuteNextExerciseCommand(object parameter)
      {
         _exerciseIndex++;
         CurrentRudimentName = _exercise.RudimentCollection[_exerciseIndex].RudimentName;
         CurrentRudimentImage = _exercise.RudimentCollection[_exerciseIndex].RudimentImage.ToString();
      }

      private bool CanExecuteNextExerciseCommand(object parameter) => _exerciseIndex < _exercise.RudimentCollection.Count - 1;
      private bool CanExecutePreviousExerciseCommand(object parameter) => _exerciseIndex > 0;

      public ICommand IncreaseTempoCommand { get; }

      private void ExecuteIncreaseTempoCommand(object parameter)
      {
         _exercise.ExerciseTempo++;
         ExerciseTempo = _exercise.ExerciseTempo.ToString();
      }

      private bool CanExecuteIncreaseTempoCommand(object parameter) => _exercise.ExerciseTempo < 300;
      private bool CanExecuteDecreaseTempoCommand(object parameter) => _exercise.ExerciseTempo > 0;


      public ICommand DecreaseTempoCommand { get; }
      private void ExecuteDecreaseTempoCommand(object parameter)
      {
         _exercise.ExerciseTempo--;
         ExerciseTempo = _exercise.ExerciseTempo.ToString();
      }

      protected void OnPropertyChanged([CallerMemberName] string name = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
   }
}
