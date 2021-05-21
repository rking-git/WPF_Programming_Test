using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Programming_Test
{
    public partial class MainWindow : Window
    {
        //Allows EditDialog.cs to access row values from data grid.
        public static string rowCopyName;
        public static int rowCopyAge;
        public static string rowCopyPostcode;
        public static double rowCopyHeight;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Button_Click_Main(object sender, RoutedEventArgs e)
        {
            //Creates a new AddDialog instance
            AddDialog newDetails = new AddDialog();

            //Event for 'newDetails' instance
            newDetails.AddDone += AddDone;

            //Shows the created Add Dialog box.
            newDetails.Show();
        }
        //Reads the 'AddDone' event, creates and populates an instance of NewEntry class and adds it to the grid.
        private void AddDone(object sender, EventArgs e)
        {
            NewEntry entry = new NewEntry();

            entry.GetName = AddDialog.thisName;
            entry.GetAge = AddDialog.thisAge;
            entry.GetPostcode = AddDialog.thisPostcode;
            entry.GetHeight = AddDialog.thisHeight;

            dataGridDisplay.Items.Add(entry);
        }

        private void Edit_Button_Click_Main(object sender, RoutedEventArgs e)
        {
            if (dataGridDisplay.SelectedCells.Any<DataGridCellInfo>())
            {
                //Creates a new EditDialog instance
                EditDialog editDetails = new EditDialog();

                //Event for 'newDetails' instance
                editDetails.EditDone += EditDone;

                //Shows the created Edit Dialog box. 
                editDetails.Show();
            }

        }
        //Reads the 'EditDone' event, creates and populates an instance of NewEntry class and replaces the current grid entry.
        private void EditDone(object sender, EventArgs e)
        {
            //Replaces current values on selected row with edited values.
            object item = dataGridDisplay.SelectedItem;

            (dataGridDisplay.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text = EditDialog.thisName;

            (dataGridDisplay.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text = EditDialog.thisAge.ToString();

            (dataGridDisplay.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text = EditDialog.thisPostcode;

            (dataGridDisplay.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text = EditDialog.thisHeight.ToString();
        }
        //Copies selected data grid values to static fields.
        private void dataGridDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dataGridDisplay.SelectedItem;

            rowCopyName = (dataGridDisplay.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            rowCopyAge = int.Parse((dataGridDisplay.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);

            rowCopyPostcode = (dataGridDisplay.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;

            rowCopyHeight = double.Parse((dataGridDisplay.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
        }
    }
}
