using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class Inventory: INotifyPropertyChanged
    {
        private int _bookId;
        public int BookId
        {
            get { return _bookId; }
            set
            {
                if (value == _bookId) return;
                _bookId = value;
                OnPropertyChanged();
            }
        }
        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                if (value == _author) return;
                _author = value;
                OnPropertyChanged();
            }
        }
        private string _bookName;
        public string BookName
        {
            get { return _bookName; }
            set
            {
                if (value == _bookName) return;
                _bookName = value;
                OnPropertyChanged();
            }
        }
        private bool _readStatus;
        public bool ReadStatus
        {
            get { return _readStatus; }
            set
            {
                if (value == _readStatus) return;
                _readStatus = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
