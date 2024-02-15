
using ProgressivePercussion.Commands;
using ProgressivePercussion.Interfaces;
using ProgressivePercussion.Models;
using System;
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
            _metronome = _exercise.Metronome;

            NextExerciseCommand = new RelayCommand(ExecuteNextExerciseCommand, CanExecuteNextExerciseCommand);
            PreviousExerciseCommand = new RelayCommand(ExecutePreviousExerciseCommand, CanExecutePreviousExerciseCommand);

            IncreaseTempoCommand = new RelayCommand(ExecuteIncreaseTempoCommand, CanExecuteIncreaseTempoCommand);
            DecreaseTempoCommand = new RelayCommand(ExecuteDecreaseTempoCommand, CanExecuteDecreaseTempoCommand);

            StartMetronomeCommand = new RelayCommand(ExecuteStartMetronomeCommand, CanExecuteStartMetronomeCommand);
            StopMetronomeCommand = new RelayCommand(ExecuteStopMetronomeCommand, CanExecuteStopMetronomeCommand);
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
                    _metronome.BeatsPerMinute = Int32.Parse( _exerciseTempo );
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

        private IMetronome _metronome;
        public IMetronome Metronome
        {
            get => _metronome;
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

        public ICommand StartMetronomeCommand { get; }
        private void ExecuteStartMetronomeCommand(object parameter)
        {
            _metronome.ShouldRunMetronome = true;
            _metronome.StartMetronome();
        }

        private bool CanExecuteStartMetronomeCommand(object parameter) => _metronome.ShouldRunMetronome == false;

        public ICommand StopMetronomeCommand { get; }
        private void ExecuteStopMetronomeCommand(object parameter)
        {
            _metronome.StopMetronome();
        }

        private bool CanExecuteStopMetronomeCommand(object parameter) => _metronome.ShouldRunMetronome == true;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
