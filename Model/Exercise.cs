using ProgressivePercussion.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressivePercussion
{
    public class Exercise : IExercise
    {
        private List<IRudiment> _rudimentCollection;
        private string _exerciseName;
        private int _tempo;
        private int _numberOfMeasures;

        public Exercise( List<IRudiment> rudimentCollection, string exerciseName, int tempo, int numberOfMeasures, IMetronome metronome )
        {
            _rudimentCollection = rudimentCollection ?? throw new ArgumentNullException(nameof(rudimentCollection));
            _exerciseName = exerciseName ?? throw new ArgumentNullException(nameof(exerciseName));
            _metronome = metronome ?? throw new ArgumentNullException(nameof(metronome));

            _tempo = tempo;
            _numberOfMeasures = numberOfMeasures;
        }

        public List<IRudiment> RudimentCollection => _rudimentCollection;

        public string ExerciseName => _exerciseName;

        public int ExerciseTempo
        {
            get => _tempo;
            set => _tempo = value;
        }

        public int NumberOfMeasures => _numberOfMeasures;

        private IMetronome _metronome;
        public IMetronome Metronome => _metronome;
    }
}
