using System.Windows.Media;

namespace ProgressivePercussion
{
   public interface IRudiment
   {
      string RudimentName { get; }
      string TargetSkill { get; }
      ImageSource RudimentImage { get; }
   }
}
