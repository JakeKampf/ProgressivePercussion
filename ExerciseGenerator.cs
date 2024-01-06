using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
   public class ExerciseGenerator : IExerciseGenerator
   {
      private IExercise _exercise;

      public ExerciseGenerator()
      {
         _exercise = GenerateExercise();
      }

      public Exercise GenerateExercise()
      {
         Rudiment rudiment = new Rudiment("RLRL", "Basics", 8, 100);

         Exercise exercise = new Exercise(new List<IRudiment> { rudiment }, "Beginner Warm Up!");

         return exercise;
      }

      public string ExerciseName => _exercise.ExerciseName;
   }
}
