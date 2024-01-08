using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
   public class ExerciseGenerator : IExerciseGenerator
   {

      public ExerciseGenerator()
      {
      }

      public Exercise GenerateExercise()
      {
         Rudiment rudiment = new Rudiment( "RLRL", "Basics" );

         Exercise exercise = new Exercise(new List<IRudiment> { rudiment }, "Beginner Warm Up!", 120, 8);

         return exercise;
      }
   }
}
