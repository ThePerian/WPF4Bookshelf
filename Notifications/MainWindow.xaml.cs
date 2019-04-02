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

namespace Notifications
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IList<Inventory> _books;

        public MainWindow()
        {
            InitializeComponent();
            _books = new List<Inventory>
            {
                new Inventory
                {
                    BookId = 1,
                    Author = "Дж. Р. Р. Толкин",
                    BookName = "Сильмариллион",
                    ReadStatus = true
                },
                new Inventory
                {
                    BookId = 1,
                    Author = "Анджей Сапковский",
                    BookName = "Башная ласточки",
                    ReadStatus = false
                }
            };

            //Связать список книг с комбобоксом для отображения в текстбоксы
            cbBooks.ItemsSource = _books;
        }

        private void BtnChangeReadStatus_Click(object sender, RoutedEventArgs e)
        {
            var book = _books.FirstOrDefault(x => x.BookId == ((Inventory)cbBooks.SelectedItem)?.BookId);
            if (book != null)
                book.ReadStatus = !book.ReadStatus;
        }
    }
}
