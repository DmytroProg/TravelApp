using System;
using System.Windows;
using System.Windows.Controls;

namespace TravelApp.WPF.Components
{
    public partial class RowRace : UserControl
    {
        public RowRace()
        {
            InitializeComponent();

            // Set the current date in the "dd/MM/yyyy" format (e.g., "20/06/2024")
            CurrentDateTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            // Handle View Details click
            MessageBox.Show("Viewing details...");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Handle Edit click
            MessageBox.Show("Editing...");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Handle Delete click
            MessageBox.Show("Deleting...");
        }
    }
}
