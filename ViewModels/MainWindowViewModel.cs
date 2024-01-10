
using ProgressivePercussion.Commands;
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
         _exerciseGenerator = new ExerciseGenerator();
         _exercise = _exerciseGenerator.GenerateExercise();

         _currentRudimentImage = _exercise.RudimentCollection[_exerciseIndex].RudimentImage.ToString();
         _currentRudimentName = _exercise.RudimentCollection[_exerciseIndex].RudimentName;

         NextExerciseCommand = new RelayCommand( ExecuteNextExerciseCommand, CanExecuteNextExerciseCommand );
         PreviousExerciseCommand = new RelayCommand( ExecutePreviousExerciseCommand, CanExecutePreviousExerciseCommand );

      }

      public string ExerciseName => _exercise.ExerciseName;
      public string ExerciseTempo => "Tempo: " + _exercise.ExerciseTempo;
      public string NumberOfMeasures => "Measures: " + _exercise.NumberOfMeasures;

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
         _currentRudimentName = _exercise.RudimentCollection[_exerciseIndex].RudimentName;
         _currentRudimentImage = _exercise.RudimentCollection[_exerciseIndex].RudimentImage.ToString();
      }

      public ICommand NextExerciseCommand { get; }
      private void ExecuteNextExerciseCommand( object parameter )
      {
         _exerciseIndex++;
         _currentRudimentName = _exercise.RudimentCollection[_exerciseIndex].RudimentName;
         _currentRudimentImage = _exercise.RudimentCollection[_exerciseIndex].RudimentImage.ToString();
      }

      private bool CanExecuteNextExerciseCommand( object parameter ) => _exerciseIndex < _exercise.RudimentCollection.Count;
      private bool CanExecutePreviousExerciseCommand(object parameter) => _exerciseIndex > 0;

      protected void OnPropertyChanged([CallerMemberName] string name = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
   }
}
