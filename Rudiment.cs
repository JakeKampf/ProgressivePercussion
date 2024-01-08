using System;

namespace ProgressivePercussion
{
   public class Rudiment : IRudiment
   {
      private string _stickingPattern;
      private string _targetSkill;

      public Rudiment( string stickingPattern, string targetSkill )
      {
         _stickingPattern = stickingPattern ?? throw new ArgumentNullException(nameof( stickingPattern ));
         _targetSkill = targetSkill ?? throw new ArgumentNullException(nameof( targetSkill ));
      }

      public string StickingPattern => _stickingPattern;

      public string TargetSkill => _targetSkill;

   }
}
