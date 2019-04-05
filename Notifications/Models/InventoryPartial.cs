using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public partial class Inventory : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(BookId):
                        break;
                    //В целях тестирования запретим добавлять книги одного автора
                    case nameof(Author):
                        if (Author.Contains("Роулинг"))
                            return "Указан недопустимый автор";
                        return CheckAuthorAndName();
                    case nameof(BookName):
                        return CheckAuthorAndName();
                    case nameof(ReadStatus):
                        break;
                }
                return string.Empty;
            }
        }

        internal string CheckAuthorAndName()
        {
            //В целях тестирования запретим определенное сочетание автора и названия книги
            if (Author.ToLower().Contains("толкин") 
                && BookName.ToLower().Contains("гарри поттер"))
            {
                return $"{Author} не писал(а) таких книг!";
            }
            return string.Empty;
        }

        public string Error
        {
            get;
        }
    }
}
