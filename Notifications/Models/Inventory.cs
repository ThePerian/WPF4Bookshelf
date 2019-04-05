using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Notifications.Models
{
    public partial class Inventory: INotifyPropertyChanged
    {
        //Избыточно, т.к. int уже не допускает Null
        private int _bookId;
        [Required]
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
        [StringLength(50)]
        public string Author
        {
            get { return _author; }
            set
            {
                if (value == _author) return;
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }
        private string _bookName;
        [StringLength(50)]
        public string BookName
        {
            get { return _bookName; }
            set
            {
                if (value == _bookName) return;
                _bookName = value;
                OnPropertyChanged(nameof(BookName));
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
        private bool _isChanged;
        public bool IsChanged
        {
            get { return _isChanged; }
            set
            {
                if (value == _isChanged) return;
                _isChanged = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged))
                IsChanged = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
