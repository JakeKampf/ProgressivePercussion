using ProgressivePercussion.Interfaces;
using ProgressivePercussion.Model;
using System;
using System.Collections.Generic;

namespace ProgressivePercussion
{
   public class ExerciseGenerator : IExerciseGenerator
   {
      private IRudimentReader _rudimentReader;

      public ExerciseGenerator( IRudimentReader rudimentReader )
      {
         _rudimentReader = rudimentReader ?? throw new ArgumentNullException(nameof( rudimentReader ));
      }

      public Exercise GenerateExercise()
      {
         List<IRudiment> rudiments = _rudimentReader.ReadInRudiments();

            Exercise exercise = new Exercise(rudiments, "Beginner Rudiments!", 120, 8, new Metronome(120, false));

         return exercise;
      }

   }
}
