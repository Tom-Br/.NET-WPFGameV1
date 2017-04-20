using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Game_Logic;

namespace Game_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        private Speler gebruiker, computer;

        public MainWindow()
        {
            InitializeComponent();
            controller = Controller.Instance;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            btnStart.Visibility = Visibility.Hidden;
            lblSpeler1.Visibility = Visibility.Hidden;
            lblSpeler1Naam.Visibility = Visibility.Hidden;
            lblSpeler2.Visibility = Visibility.Hidden;
            lblSpeler2Naam.Visibility = Visibility.Hidden;
            lblSpeler1H.Visibility = Visibility.Hidden;
            lblSpeler1Health.Visibility = Visibility.Hidden;
            lblSpeler2H.Visibility = Visibility.Hidden;
            lblSpeler2Health.Visibility = Visibility.Hidden;
            lblPower.Visibility = Visibility.Hidden;
            sldPower.Visibility = Visibility.Hidden;
            lblPowerLvl.Visibility = Visibility.Hidden;
            btnValAan.Visibility = Visibility.Hidden;
        }

        private void txtMonsterName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtMonsterName.Clear();
            btnStart.Visibility = Visibility.Visible;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            controller.StartGame(txtMonsterName.Text);
            gebruiker = controller.Spel.Gebruiker;
            computer = controller.Spel.Computer;

            lblSpeler1Naam.Content = gebruiker.Naam;
            lblSpeler2Naam.Content = computer.Naam;

            Nieuwe_Ronde();

            sldPower.IsSelectionRangeEnabled = true;
            sldPower.SelectionStart = 0;
            sldPower.SelectionEnd = 100;

            txtMonsterName.Visibility = Visibility.Hidden;
            btnStart.Visibility = Visibility.Hidden;
            lblRonde.Visibility = Visibility.Visible;
            lblRondeOutput.Visibility = Visibility.Visible;
            lblSpeler1.Visibility = Visibility.Visible;
            lblSpeler1Naam.Visibility = Visibility.Visible;
            lblSpeler2.Visibility = Visibility.Visible;
            lblSpeler2Naam.Visibility = Visibility.Visible;
            lblSpeler1H.Visibility = Visibility.Visible;
            lblSpeler1Health.Visibility = Visibility.Visible;
            lblSpeler2H.Visibility = Visibility.Visible;
            lblSpeler2Health.Visibility = Visibility.Visible;
            lblPower.Visibility = Visibility.Visible;
            sldPower.Visibility = Visibility.Visible;
            lblPowerLvl.Visibility = Visibility.Visible;
            btnValAan.Visibility = Visibility.Visible;
        }

        private void btnValAan_Click(object sender, RoutedEventArgs e)
        {
            double attackValue;
            attackValue = sldPower.Value;
            controller.Spel.Ronde.Last().MoveSpeler = gebruiker.Aanvallen(computer, attackValue);

            SetLimits_sldPower(attackValue);
            sldPower.Value = 0;
            Computer_Move();
            Nieuwe_Ronde();
        }

        private void Computer_Move()
        {
            computer.Aanvallen(gebruiker, 10);
        }

        private void Nieuwe_Ronde()
        {
            lblSpeler1Health.Content = gebruiker.Gezondheid;
            lblSpeler2Health.Content = computer.Gezondheid;
            controller.Spel.NieuweRonde();
            lblRondeOutput.Content = controller.Spel.Ronde.Last().RondeID;
        }

        private void SetLimits_sldPower(double attack)
        {
            double max;
            max = sldPower.SelectionEnd - attack;

            if (max > 0)
            {
                sldPower.SelectionEnd = max;
            }
        }

        private void sldPower_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sldPower.IsSelectionRangeEnabled)
            {
                if (e.NewValue > sldPower.SelectionEnd)
                {
                    sldPower.Value = e.OldValue;
                }
            }
        }
    }
}
