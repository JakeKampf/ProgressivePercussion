﻿using ProgressivePercussion.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

         Exercise exercise = new Exercise( rudiments, "Beginner Rudiments!", 120, 8);

         return exercise;
      }

   }
}
