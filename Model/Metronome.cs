using ProgressivePercussion.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressivePercussion.Model
{
    public class Metronome : IMetronome
    {
        private int _beatsPerMinute;
        private bool _shouldRunMetronome;

        public Metronome(int beatsPerMinute, bool shouldRunMetronome)
        {
            _beatsPerMinute = beatsPerMinute;
            _shouldRunMetronome = shouldRunMetronome;
        }

        public int BeatsPerMinute
        {
            get => _beatsPerMinute;
            set => _beatsPerMinute = value;
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

        public async Task StartMetronome()
        {
            _shouldRunMetronome = true;
            await RunMetrononome();
        }

        public void StopMetronome()
        {
            _shouldRunMetronome = false;
        }

        private async Task RunMetrononome()
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
                await Task.Delay(millisecondsBetweenBeeps);
            }
        }
    }
}
