using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifications.Models;

namespace Notifications.Commands
{
    internal class AddBookCommand : CommandBase
    {
        private readonly MainWindow _mainWindow;
        private readonly IList<Inventory> _books;

        public AddBookCommand(IList<Inventory> books, MainWindow mainWindow)
        {
            _books = books;
            _mainWindow = mainWindow;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var maxCount = _books?.Max(x => x?.BookId) ?? 0;
            _books?.Add(
                new Inventory
                {
                    BookId = ++maxCount,
                    Author = (_mainWindow.tbAuthor.Text == "") 
                        ? "Без автора" : _mainWindow.tbAuthor.Text,
                    BookName = (_mainWindow.tbBookName.Text == "") 
                        ? "Без названия" : _mainWindow.tbBookName.Text,
                    ReadStatus = _mainWindow.cbxReadStatus.IsChecked ?? false
                });
        }
    }
}
