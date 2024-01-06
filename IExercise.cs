using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
   public interface IExercise
   {
      public string ExerciseName { get; }
      public List<IRudiment> RudimentCollection { get; }
   }
}
