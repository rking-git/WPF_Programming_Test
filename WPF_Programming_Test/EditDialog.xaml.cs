using System;
using System.Linq;
using System.Windows;

namespace WPF_Programming_Test
{
    //Controls dialog box when Edit button is clicked.
    public partial class EditDialog : Window
    {
        public event EventHandler EditDone;
        //public types to be passed to MainWindow.cs
        public static string thisName;
        public static int thisAge;
        public static string thisPostcode;
        public static double thisHeight;
        public EditDialog()
        {
            InitializeComponent();
            //Sets the text fields to selected grid row values during editing.
            nameInput.Text = MainWindow.rowCopyName;
            ageInput.Text = MainWindow.rowCopyAge.ToString();
            postcodeInput.Text = MainWindow.rowCopyPostcode;
            heightInput.Text = MainWindow.rowCopyHeight.ToString();
        }
        //OK button: fills fields if conditions are met
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            //checks if age and height are correct.
            int number;
            double doubleNumber;
            bool ageIsInt = Int32.TryParse(ageInput.Text, out number) && (Int32.Parse(ageInput.Text) <= 110) && (Int32.Parse(ageInput.Text) >= 0);
            bool heightIsDouble = double.TryParse(heightInput.Text, out doubleNumber) && (Int32.Parse(heightInput.Text) <= 250) && (Int32.Parse(heightInput.Text) >= 0) && heightInput.Text.Length <= 4;

            //Checks if postcode and name are correct.
            bool postcodeIsCorrect = postcodeInput.Text.Any(char.IsDigit) && postcodeInput.Text.Any(char.IsLetter);
            bool nameIsShort = nameInput.Text.Length <= 50;

            if (nameIsShort)
            {
                thisName = nameInput.Text;
            }
            else
            {
                MessageBox.Show("Please use a name that's under 50 characters total");
            }

            if (ageIsInt)
            {
                thisAge = int.Parse(ageInput.Text);
            }
            else
            {
                MessageBox.Show("Please use a number to represent your age in years");
            }

            if (postcodeIsCorrect)
            {
                thisPostcode = postcodeInput.Text;
            }
            else
            {
                MessageBox.Show("Please use a correct postcode");
            }

            if (heightIsDouble)
            {
                thisHeight = double.Parse(heightInput.Text);
            }
            else
            {
                MessageBox.Show("Please use a number to represent your height in metres");
            }

            //Checks if text fields are full and correct.
            if (nameInput.Text != null && ageInput.Text != null && postcodeInput.Text != null && heightInput.Text != null && ageIsInt && heightIsDouble && postcodeIsCorrect && nameIsShort)
            {
                this.Close();
                EditDone.Invoke(this, EventArgs.Empty);
            }
            else if(nameInput.Text == null || ageInput.Text == null || postcodeInput.Text == null || heightInput.Text == null)
            {
                MessageBox.Show("Please fill out all of the text boxes correctly");
            }
        }
        //Cancel button: closes this window.
        private void Edit_Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}