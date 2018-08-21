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

namespace MortgageCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

        }

        //Varibles
        static public double AmountBorrowed { get; set; }
        static public double InterestRate { get; set; }
        static public int MortgagePeriod { get; set; }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //Get & Parse values
            AmountBorrowed = (double)Int32.Parse(Amount.Text);

            //Get Interest rate
            decimal result;
            if (Decimal.TryParse(Interest.Text, out result))
                InterestRate = (double)result;
            //Get mortgage period
            MortgagePeriod = Int32.Parse(Period.Text);

            //Calculate mortgage
            MonthlyPayments.Text = CalcMortgage(AmountBorrowed, InterestRate, MortgagePeriod);

        }

        private string CalcMortgage(double amountBorrowed, double interestRate, int mortgagePeriod)
        {

            double p = amountBorrowed;
            double r = ConvertToMonthlyInterest(interestRate);
            double n = YearsToMonths(mortgagePeriod);

            var c = (decimal)(((r * p) * Math.Pow((1 + r), n)) / 
                    (Math.Pow((1 + r), n) - 1));

            return ($"${Math.Round(c, MidpointRounding.AwayFromZero)}");

        }

        private int YearsToMonths(int years)
        {

            return (12 * years);

        }

        private double ConvertToMonthlyInterest(double percent)
        {

            return (percent / 12) / 100;

        }
    }
}
