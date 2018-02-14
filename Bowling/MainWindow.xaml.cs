using System.Linq;
using System.Windows;

namespace Bowling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BowlingGame BG { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BG = new BowlingGame();
            DataContext = BG.Rounds;
        }

        private void BtnThrow_Click(object sender, RoutedEventArgs e)
        {
            if (BG.Rounds.Count < 11)
            {
                BG.Throw();
                LabelSum.Content = BG.Sum;

                if (BG.Rounds.Count == 11)
                {
                    if (BG.Rounds.ElementAt(9).IsStrike)
                    {
                        BG.Throw();
                        LabelSum.Content = BG.Sum;
                    }
                    if (BG.Rounds.ElementAt(9).IsSpare)
                    {
                        BG.Throw();
                        LabelSum.Content = BG.Sum;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Zdobyłeś: {BG.Sum} punktów", "Koniec gry", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
