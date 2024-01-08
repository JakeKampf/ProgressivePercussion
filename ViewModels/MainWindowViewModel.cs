using System;

namespace ProgressivePercussion.ViewModels
{
   public class MainWindowViewModel : IMainWindowViewModel
   {
      private IExerciseGenerator _exerciseGenerator;
      private IExercise _exercise;

      public MainWindowViewModel()
      {
         _exerciseGenerator = new ExerciseGenerator();
         _exercise = _exerciseGenerator.GenerateExercise();
      }

      public string ExerciseName => _exercise.ExerciseName;
      public int ExerciseTempo => _exercise.ExerciseTempo;
      public int NumberOfMeasures => _exercise.NumberOfMeasures;
   }
}
