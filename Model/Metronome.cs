using ProgressivePercussion.Interfaces;
using System;
using System.Threading;

namespace ProgressivePercussion.Model
{
   public class Metronome : IMetronome
   {
      private int _beatsPerMinute;
      private bool _shouldRunMetronome;

      public Metronome( int beatsPerMinute, bool shouldRunMetronome )
      {
         _beatsPerMinute = beatsPerMinute;
         _shouldRunMetronome = shouldRunMetronome;

         StartMetronome();
      }

      public int BeatsPerMinute 
      { 
         get => throw new NotImplementedException(); 
         set => throw new NotImplementedException(); 
      }

      public bool ShouldRunMetronome 
      { 
         get => _shouldRunMetronome;
         set
         {
            if (_shouldRunMetronome != value)
            {
               _shouldRunMetronome = value;
            }
         }
      }

      public void StartMetronome()
      {
         RunMetrononome();
      }

      public void StopMetronome()
      {
         throw new NotImplementedException();
      }
      
      private void RunMetrononome()
      {
         if (_beatsPerMinute <= 0)
         {
            Console.WriteLine("Invalid input. Number of beeps per minute must be greater than zero.");
            return;
         }

         int millisecondsBetweenBeeps = (int)(60000.0 / _beatsPerMinute);

         Console.WriteLine($"Beeping {_beatsPerMinute} times per minute...");

         while (_shouldRunMetronome)
         {
            Console.Beep(); 
            Thread.Sleep(millisecondsBetweenBeeps);
         }
      }
   }
}
