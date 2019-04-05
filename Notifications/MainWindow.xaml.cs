using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Notifications.Models;
using Notifications.Commands;
using System.Collections.ObjectModel;

namespace Notifications
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ObservableCollection<Inventory> _books;

        private ICommand _changeReadStatusCommand = null;
        public ICommand ChangeReadStatusCmd =>
            _changeReadStatusCommand ?? (_changeReadStatusCommand = new ChangeReadStatusCommand());
        private ICommand _removeBookCommand = null;
        public ICommand RemoveBookCmd =>
            _removeBookCommand
            ?? (_removeBookCommand = new RemoveBookCommand(_books));
        private ICommand _addBookCommand = null;
        public ICommand AddBookCmd =>
            _addBookCommand 
            ?? (_addBookCommand = new AddBookCommand(_books, this));

        public MainWindow()
        {
            InitializeComponent();
            _books = new ObservableCollection<Inventory>
            {
                new Inventory
                {
                    BookId = 1,
                    Author = "Дж. Р. Р. Толкин",
                    BookName = "Сильмариллион",
                    ReadStatus = true,
                    IsChanged = false
                },
                new Inventory
                {
                    BookId = 2,
                    Author = "Анджей Сапковский",
                    BookName = "Башная ласточки",
                    ReadStatus = false,
                    IsChanged = false
                }
            };

            //Связать список книг с комбобоксом для отображения в текстбоксы
            cboBooks.ItemsSource = _books;
        }
    }
}
