using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookshelfDALEF.Models;

namespace Notifications.Commands
{
    public class ChangeReadStatusCommand : CommandBase, ICommand
    {
        public override bool CanExecute(object parameter)
        {
            return (parameter as Inventory) != null;
        }

        public override void Execute(object parameter)
        {
            ((Inventory)parameter).ReadStatus = !((Inventory)parameter).ReadStatus;
        }
    }
}
