﻿using Book_MVVM_Step_1.Model;

namespace Book_MVVM_Step_1.ViewModel
{
    class BookViewModel
    {
        private Book _book;

        public BookViewModel()
        {
            _book = CreateBook();
        }

        public string Title
        {
            get { return _book.Title; }
            set { _book.Title = value; }
        }

        public string Author
        {
            get { return _book.Author; }
            set { _book.Author = value; }
        }

        public double Price
        {
            get { return _book.Price; }
            set { _book.Price = value; }
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
