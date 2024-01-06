using System;

namespace ProgressivePercussion
{
   public class Rudiment : IRudiment
   {
      private string _stickingPattern;
      private string _targetSkill;
      private int _numberOfMeasures;
      private int _tempo; 

      public Rudiment( string stickingPattern, string targetSkill, int numberOfMeasures, int tempo )
      {
         _stickingPattern = stickingPattern ?? throw new ArgumentNullException(nameof( stickingPattern ));
         _targetSkill = targetSkill ?? throw new ArgumentNullException(nameof( targetSkill ));
         _numberOfMeasures = numberOfMeasures;
         _tempo = tempo;
      }

      public string StickingPattern => _stickingPattern;

      public string TargetSkill => _targetSkill;

      public int NumberOfMeasures => _numberOfMeasures;

      public int Tempo => _tempo;
   }
}
