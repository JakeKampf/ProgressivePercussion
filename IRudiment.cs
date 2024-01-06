using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
   public interface IRudiment
   {
      string StickingPattern { get; }
      string TargetSkill { get; }
      int NumberOfMeasures { get; }
      int Tempo { get; }
   }
}
