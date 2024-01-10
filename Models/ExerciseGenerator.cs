using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProgressivePercussion
{
   public class ExerciseGenerator : IExerciseGenerator
   {

      public ExerciseGenerator()
      {
      }

      public Exercise GenerateExercise()
      {
         Image myImage3 = new Image();
         BitmapImage bi3 = new BitmapImage();
         bi3.BeginInit();
         bi3.UriSource = new Uri("C://Users//jacob//source//repos//ProgressivePercussion//Resources//Rudiments//BeginnerRudiments//SingleStrokeRoll//SingleStrokeRoll.jpeg", UriKind.Relative);
         bi3.EndInit();
         myImage3.Stretch = Stretch.Fill;
         myImage3.Source = bi3;

         Image myImage = new Image();
         BitmapImage bi = new BitmapImage();
         bi.BeginInit();
         bi.UriSource = new Uri("C://Users//jacob//source//repos//ProgressivePercussion//Resources//Rudiments//BeginnerRudiments//MultipleBounceRoll//MultipleBounceRoll.jpeg", UriKind.Relative);
         bi.EndInit();
         myImage.Stretch = Stretch.Fill;
         myImage.Source = bi;

         Rudiment rudiment = new Rudiment( "Single Stroke Roll", "Basics", myImage3.Source);
         Rudiment rudiment2 = new Rudiment("Multiple Bounce Roll", "Basics", myImage.Source);

         Exercise exercise = new Exercise(new List<IRudiment> { rudiment, rudiment2 }, "Beginner Warm Up!", 120, 8);
         

         return exercise;
      }
   }
}
