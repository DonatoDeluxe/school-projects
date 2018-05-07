using Book_MVVM_Step_2.Model;
using System.ComponentModel;

namespace Book_MVVM_Step_2.ViewModel
{
    class BookViewModel : INotifyPropertyChanged
    {
        private Book _book;

        public BookViewModel()
        {
            _book = CreateBook();
        }

        public string Title
        {
            get { return _book.Title; }
            set {
                _book.Title = value;
                RaisePropertyChanged("Title");
            }
        }

        public string Author
        {
            get { return _book.Author; }
            set
            {
                _book.Author = value;
                RaisePropertyChanged("Author");
            }
        }

        public double Price
        {
            get { return _book.Price; }
            set
            {
                _book.Price = value;
                RaisePropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private Book CreateBook()
        {
            return new Book()
            {
                Title = "Harry Potter - Stein der Weisen",
                Author = "J.K. Rowling",
                Price = 59.95
            };
        }
    }
}
