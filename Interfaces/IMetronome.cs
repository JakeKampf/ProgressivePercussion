using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion.Interfaces
{
   public interface IMetronome
   { 
      public int BeatsPerMinute { get; set; }
      public bool ShouldRunMetronome { get; set; }
      public void StartMetronome();
      public void StopMetronome();
   }
}
