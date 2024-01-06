using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
   public class Exercise : IExercise
   {
      private List<IRudiment> _rudimentCollection;
      private string _exerciseName;

      public Exercise( List<IRudiment> rudimentCollection, string exerciseName )
      {
         _rudimentCollection = rudimentCollection ?? throw new ArgumentNullException(nameof( rudimentCollection ));
         _exerciseName = exerciseName ?? throw new ArgumentNullException(nameof( exerciseName ));
      }

      public List<IRudiment> RudimentCollection => _rudimentCollection;

      public string ExerciseName => _exerciseName;
   }
}
