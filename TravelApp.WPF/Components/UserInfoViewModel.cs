using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace TravelApp.WPF
{
    internal class UserInfoViewModel
    {
        public ICommand SaveCommand { get; set; }

        public string FullName { get; set; }
        public string NumberOrEmail { get; set; }

        public UserInfoViewModel() {
            SaveCommand = new TestCommand();
        }
    }

   

}
