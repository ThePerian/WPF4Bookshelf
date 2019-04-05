using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public partial class Inventory : EntityBase, IDataErrorInfo
    {

        public string Error { get; }

        public string this[string columnName]
        {
            get
            {
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(BookId):
                        break;
                    case nameof(Author):
                        hasError = CheckAuthorAndBookName();
                        if (Author.ToLower().Contains("роулинг"))
                        {
                            AddError(nameof(Author), "Указан недопустимый автор");
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Author));
                        break;
                    case nameof(BookName):
                        hasError = CheckAuthorAndBookName();
                        if (!hasError) ClearErrors(nameof(BookName));
                        break;
                    case nameof(ReadStatus):
                        break;
                }
                return string.Empty;
            }
        }

        internal bool CheckAuthorAndBookName()
        {
            //В целях тестирования запретим сочетание определенного автора и книги
            if (Author.ToLower().Contains("толкин") 
                && BookName.ToLower().Contains("гарри поттер"))
            {
                AddError(nameof(Author), "Этот автор не писал таких книг");
                AddError(nameof(BookName), "Этот автор не писал таких книг");
                return true;
            }
            return false;
        }
    }
}
