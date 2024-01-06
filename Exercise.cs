using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
   public class Exercise : IExercise
   {
      private List<IRudiment> _rudimentCollection; 

      public Exercise( List<IRudiment> rudimentCollection )
      {
         _rudimentCollection = rudimentCollection ?? throw new ArgumentNullException(nameof( rudimentCollection ));
      }

      public List<IRudiment> RudimentCollection => _rudimentCollection;
   }
}
