using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Components.Pages.Data
{
    public abstract class Books
    {
            private int ISBN;
            private string Title;
            private string Genre;
            private string Author;
            private DateOnly DatePublished;
            private string PublisherName;
            private int Pages_num;

            private string Available;
            public int GetPagesnum()
            {
                return Pages_num;
            }
            public void SetPagesnum(int pagesnum)
            {
                Pages_num = pagesnum;
            }
            public string GetPublisherName()
            {
                return PublisherName;
            }
            public void SetPublisherName(string publisherName)
            {
                PublisherName = publisherName;
            }
            public DateOnly GetPublishDate()
            {
                return DatePublished;
            }
            public void SetPublishDate(DateOnly datepublished)
            {
                DatePublished = datepublished;
            }
            public int GetISBN()
            {
                return ISBN;
            }
            public void SetISBN(int isbn)
            {
                ISBN = isbn;
            }
            public string GetTitle()
            {
                return Title;
            }
            public void SetTitle(string title)
            {
                Title = title;
            }
            public string GetGenre()
            {
                return Genre;
            }
            public void SetGenre(string genre)
            {
                Genre = genre;
            }
            public string GetAuthor()
            {
                return Author;
            }
            public void SetAuthor(string author)
            {
                Author = author;
            }
            public string IsAvailable()
            {
                return Available;
            }
            public void SetAvailability(string isAvailable)
            {
                Available = isAvailable;
            }
            public abstract void ReturnAllBooks(List<BooksDBManager> bookslist);
            public abstract void AvailableBooks(List<BooksDBManager> bookslist);
            public abstract void BorrowedBooks(List<BooksDBManager> bookslist);
            public abstract void AddBooks();
            public abstract void RemoveBooks();
            public abstract void UpdateBooks();
          

            public abstract void DisplayAvailableBooks(List<BooksDBManager> bookList);


            public abstract void DisplayBorrowedBooks(List<BooksDBManager> bookList);


        
    }
}
