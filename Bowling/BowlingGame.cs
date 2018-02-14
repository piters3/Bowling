using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Bowling
{
    public class BowlingGame : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private static Random _rnd { get; set; }
        private int _sum { get; set; }
        public ObservableCollection<Round> Rounds { get; set; }


        public int Sum
        {
            get
            {
                return _sum;
            }
            set
            {
                _sum = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Sum)));
            }
        }


        public BowlingGame()
        {
            _rnd = new Random();
            Rounds = new ObservableCollection<Round>() { new Round() };
        }

        public int ThrowRandom(int max = 0)
        {
            int randomThrow = _rnd.Next(1, 11 - max);
            Sum += randomThrow;
            return randomThrow;
        }

        public int Throw(int number = 10)
        {            
            Round last = Rounds.Last();

            if (last.FirstThrow == 0)
            {              
                last.FirstThrow = number;
                Sum += number;          
            }
            else
            {
                if (number == 10)
                {
                    last.IsStrike = true;
                    last.SecondThrow = 0;
                }
                else
                {
                    last.SecondThrow = number;
                    Sum += number;
                }            
                if (last.FirstThrow + last.SecondThrow == 10 && last.IsStrike == false)
                {
                    last.IsSpare = true;
                }
                last.RoundPoints = last.FirstThrow + last.SecondThrow;
                AddSpareBonus();
                AddStrikeBonus();
                Rounds.Add(new Round());
            }
           
            return number;
        }

        public void ThrowRound(int number = 10)
        {
            Round round = new Round();

            AddStrikeBonus();

            int firtsThrow = Throw(number);
            int secondThrow;

            AddSpareBonus();

            if (firtsThrow == 10)
            {
                round.IsStrike = true;
                secondThrow = 0;
            }
            else
            {
                secondThrow = Throw(firtsThrow);
            }

            if (firtsThrow + secondThrow == 10 && round.IsStrike == false)
            {
                round.IsSpare = true;
            }

            round.FirstThrow = firtsThrow;
            round.SecondThrow = secondThrow;
            round.RoundPoints = firtsThrow + secondThrow;

            Rounds.Add(round);
        }

        private void AddSpareBonus()
        {
            if (Rounds.Count > 1)
            {
                var previousRound = Rounds.ElementAt(Rounds.Count - 2);
                if (previousRound.IsSpare)
                {
                    previousRound.RoundPoints = Sum;
                    Sum += previousRound.FirstThrow;
                }
            }
        }

        private void AddStrikeBonus()
        {
            if (Rounds.Count > 1)
            {
                var secondPreviousRound = Rounds.ElementAt(Rounds.Count - 2);
                if (secondPreviousRound.IsStrike)
                {
                    int temp = secondPreviousRound.RoundPoints;
                    secondPreviousRound.RoundPoints = Sum;
                    Sum += temp;
                }
            }
            if (Rounds.Count > 0)
            {
                var previousRound = Rounds.ElementAt(Rounds.Count - 1);
                if (previousRound.IsStrike)
                {
                    int temp = previousRound.RoundPoints;
                    //previousRound.RoundPoints = Sum;
                    Sum += temp;
                }
            }

        }
    }
}
