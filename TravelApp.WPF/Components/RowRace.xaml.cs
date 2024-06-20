using System;
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
    }
}
