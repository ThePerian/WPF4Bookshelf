using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Notifications.Commands;
using BookshelfDALEF.Models;
using BookshelfDALEF.Repos;

namespace Notifications.ViewModels
{
    public class MainWindowViewModel
    {
        public IList<Inventory> Books { get; set; }

        private MainWindow _mainWindow;

        private ICommand _changeReadStatusCommand = null;
        public ICommand ChangeReadStatusCmd =>
            _changeReadStatusCommand ?? (_changeReadStatusCommand = new ChangeReadStatusCommand());
        private ICommand _removeBookCommand = null;
        public ICommand RemoveBookCmd =>
            _removeBookCommand
            ?? (_removeBookCommand = new RemoveBookCommand(Books));
        private ICommand _addBookCommand = null;
        public ICommand AddBookCmd =>
            _addBookCommand
            ?? (_addBookCommand = new AddBookCommand(Books, _mainWindow));

        public MainWindowViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;

            Books = new ObservableCollection<Inventory>(new InventoryRepo().GetAll());
        }
    }
}
