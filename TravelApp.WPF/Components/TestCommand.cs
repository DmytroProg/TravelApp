using System.Windows;
using System.Windows.Input;

namespace TravelApp;

internal class TestCommand : ICommand
{

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }
     
    public void Execute(object? parameter)
    {
        MessageBox.Show("Test Command");
    }
}
