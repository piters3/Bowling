using System.ComponentModel;

namespace Bowling
{
    public class Round : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private int _firstThrow;
        private int _secondThrow;


        public int FirstThrow
        {
            get
            {
                return _firstThrow;
            }
            set
            {
                _firstThrow = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(FirstThrow)));
            }
        }

        public int SecondThrow
        {
            get
            {
                return _secondThrow;
            }
            set
            {
                _secondThrow = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SecondThrow)));
            }
        }

        public int RoundPoints { get; set; }
        public bool IsStrike { get; set; }
        public bool IsSpare { get; set; }

        public Round() { }
        public Round(int first, int second)
        {
            FirstThrow = first;
            SecondThrow = second;
        }
    }
}
