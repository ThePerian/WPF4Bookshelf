using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BookshelfDALEF.Models;

namespace Notifications.Commands
{
    internal class RemoveBookCommand : CommandBase
    {
        private readonly IList<Inventory> _books;

        public RemoveBookCommand(IList<Inventory> books)
        {
            _books = books;
        }

        public override bool CanExecute(object parameter)
        {
            return ((Inventory)parameter) != null && _books != null && _books.Count > 0;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _books.Remove((Inventory) parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
