using System;
using System.Windows.Controls;

namespace TravelApp.WPF.Components
{
    public partial class RowRace : UserControl
    {
        public RowRace()
        {
            InitializeComponent();

            DateComboBox.Items.Add("20.08.2025");
            DateComboBox.Items.Add("12.06.2025");
            DateComboBox.Items.Add("30.07.2027");
            DateComboBox.Items.Add("13.09.2028");
            DateComboBox.Items.Add("05.10.2024");
            DateComboBox.Items.Add("25.12.2027");
            DateComboBox.Items.Add("21.11.2026");
            DateComboBox.Items.Add("24.02.2023");
            DateComboBox.Items.Add("18.03.2024");
            DateComboBox.Items.Add("11.01.2023");
        }
    }
}
