using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
   public interface IExercise
   {
      public string ExerciseName { get; }
      public int ExerciseTempo { get; }
      public int NumberOfMeasures { get; }
      public List<IRudiment> RudimentCollection { get; }
   }
}
