using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
   public interface IExercise
   {
      public List<IRudiment> RudimentCollection { get; }
   }
}
