using System.Threading.Tasks;

namespace ProgressivePercussion.Interfaces
{
   public interface IMetronome
   { 
      public int BeatsPerMinute { get; set; }
      public bool ShouldRunMetronome { get; set; }
      public Task StartMetronome();
      public void StopMetronome();
    }
}
