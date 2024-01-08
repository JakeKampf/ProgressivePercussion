using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
   public class Exercise : IExercise
   {
      private List<IRudiment> _rudimentCollection;
      private string _exerciseName;
      private int _tempo;
      private int _numberOfMeasures; 

      public Exercise( List<IRudiment> rudimentCollection, string exerciseName, int tempo, int numberOfMeasures )
      {
         _rudimentCollection = rudimentCollection ?? throw new ArgumentNullException(nameof( rudimentCollection ));
         _exerciseName = exerciseName ?? throw new ArgumentNullException(nameof( exerciseName ));
         _tempo = tempo;
         _numberOfMeasures = numberOfMeasures;
      }

      public List<IRudiment> RudimentCollection => _rudimentCollection;

      public string ExerciseName => _exerciseName;

      public int ExerciseTempo => _numberOfMeasures;

      public int NumberOfMeasures => _numberOfMeasures;
   }
}
