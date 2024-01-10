using System;
using System.ComponentModel;
using System.Windows.Media;

namespace ProgressivePercussion
{
   public class Rudiment : IRudiment, INotifyPropertyChanged
   {
      private string _rudimentName;
      private string _targetSkill;
      private ImageSource _rudimentImage;

      public Rudiment( string rudimentName, string targetSkill, ImageSource rudimentImage )
      {
         _rudimentName = rudimentName ?? throw new ArgumentNullException( nameof( rudimentName ) );
         _targetSkill = targetSkill ?? throw new ArgumentNullException( nameof( targetSkill ) );
         _rudimentImage = rudimentImage ?? throw new ArgumentNullException( nameof( rudimentImage ) );
      }

      public string RudimentName => _rudimentName;

      public string TargetSkill => _targetSkill;

      public ImageSource RudimentImage => _rudimentImage;

      public event PropertyChangedEventHandler PropertyChanged;
   }
}
