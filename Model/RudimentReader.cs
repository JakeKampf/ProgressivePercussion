using ProgressivePercussion.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace ProgressivePercussion.Models
{
   public class RudimentReader : IRudimentReader
   {
      private const string BEGINNERPATH = "C://Users//jake.kampf//source//repos//ProgressivePercussion//Resources//Rudiments//BeginnerRudiments";

      public List<IRudiment> ReadInRudiments()
      {
         List<IRudiment> rudimentList = new List<IRudiment>();

         try
         {
            if (Directory.Exists( BEGINNERPATH ))
            {
               string[] rudimentFolders = Directory.GetDirectories( BEGINNERPATH );

               foreach (string path in rudimentFolders)
               {
                  rudimentList.Add( AssembleRudiment(path) );
               }
            }
            else
            {
               Console.WriteLine("Directory does not exist.");
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine("Error: " + ex.Message);
         }

         return rudimentList;
      }

      private IRudiment AssembleRudiment( string path )
      {
         if ( Directory.Exists(path) )
         {
            string rudimentName = Path.GetFileName(path);

            string[] jpegFiles = Directory.GetFiles(path, "*.jpeg");

            BitmapImage rudimentImage = new BitmapImage();
            rudimentImage.BeginInit();
            rudimentImage.UriSource = new Uri(jpegFiles[0], UriKind.Relative);
            rudimentImage.EndInit();

            return new Rudiment(rudimentName, "Basics", rudimentImage);
         }
         else
         {
            return null;
         }
      }
   }
}
