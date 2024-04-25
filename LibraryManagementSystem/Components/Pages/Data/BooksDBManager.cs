using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Components.Pages.Data
{

    public class BooksDBManager : Books
    {

        DBConnection database = new DBConnection();
        string connectionString = DBConnection.builder.ConnectionString;
        public override void AddBooks()
        {
            int isbn = GetISBN();
            string title = GetTitle();
            string author = GetAuthor();
            DateOnly publishdate = GetPublishDate();
            string publisheddate = publishdate.ToString("yyyy-MM-dd");
            string publishername = GetPublisherName();
            int pagesnum = GetPagesnum();
            string genre = GetGenre();
            using (var connection2 = new MySqlConnection(connectionString))
            {
                connection2.Open();
                string query = $"INSERT INTO books Values({isbn},'{title}', '{author}',Date_Format('{publisheddate}','%Y-%m-%d'),'{publishername}',{pagesnum},'{genre}','YES')";
                MySqlCommand command = new MySqlCommand(query, connection2);
                command.ExecuteNonQuery();
                connection2.Close();

            }
        }
        public override void RemoveBooks()
        {
            int isbn = GetISBN();
            string title = GetTitle();
            using (var connection3 = new MySqlConnection(connectionString))
            {
                connection3.Open();
                string query = $"Delete From books Where books_isbn_no = {isbn}";
                MySqlCommand command = new MySqlCommand(query, connection3);
                int affected = command.ExecuteNonQuery();
                connection3.Close();
            }
        }
        public override void UpdateBooks()
        {
            int isbn = GetISBN();
            string title = GetTitle();
            string author = GetAuthor();
            DateOnly publishdate = GetPublishDate();
            string publisheddate = publishdate.ToString("yyyy-MM-dd");
            string publishername = GetPublisherName();
            int pagesnum = GetPagesnum();
            string genre = GetGenre();
            using (var connection4 = new MySqlConnection(connectionString))
            {
                connection4.Open();
                string query = $"Update books Set books_title = '{title}', books_author = '{author}', date_published = '{publisheddate}', books_publisher = '{publishername}', no_of_pages = {pagesnum}, books_genre = '{genre}' WHERE books_isbn_no = {isbn} ";
                MySqlCommand command = new MySqlCommand(query, connection4);
                command.ExecuteNonQuery();
                connection4.Close();
            }

        }
        public override void AvailableBooks(List<BooksDBManager> booklist)
        {
            using (var connection5 = new MySqlConnection(connectionString))
            {
                connection5.Open();
                string query = "Select * from Books WHERE available = 'YES'";
                MySqlCommand command = new MySqlCommand(query, connection5);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BooksDBManager BooksDBManager = new BooksDBManager();
                    int isbn = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author = reader.GetString(2);
                    DateOnly datepublished = reader.GetDateOnly(3);
                    string publisher = reader.GetString(4);
                    int numpages = reader.GetInt32(5);
                    string genre = reader.GetString(6);
                    BooksDBManager.SetISBN(isbn);
                    BooksDBManager.SetTitle(title);
                    BooksDBManager.SetAuthor(author);
                    BooksDBManager.SetPublishDate(datepublished);
                    BooksDBManager.SetPublisherName(publisher);
                    BooksDBManager.SetPagesnum(numpages);
                    BooksDBManager.SetGenre(genre);
                    booklist.Add(BooksDBManager);
                }
                connection5.Close();
            }
        }
        public override void BorrowedBooks(List<BooksDBManager> bookslist)
        {
            using (var connection7 = new MySqlConnection(connectionString))
            {
                connection7.Open();
                string query = "Select * from Books WHERE available = 'NO'";
                MySqlCommand command = new MySqlCommand(query, connection7);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BooksDBManager BooksDBManager = new BooksDBManager();
                    int isbn = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author = reader.GetString(2);
                    DateOnly datepublished = reader.GetDateOnly(3);
                    string publisher = reader.GetString(4);
                    int numpages = reader.GetInt32(5);
                    string genre = reader.GetString(6);
                    BooksDBManager.SetISBN(isbn);
                    BooksDBManager.SetTitle(title);
                    BooksDBManager.SetAuthor(author);
                    BooksDBManager.SetPublishDate(datepublished);
                    BooksDBManager.SetPublisherName(publisher);
                    BooksDBManager.SetPagesnum(numpages);
                    BooksDBManager.SetGenre(genre);
                    bookslist.Add(BooksDBManager);
                }
                connection7.Close();
            }
        }

        public override void ReturnAllBooks(List<BooksDBManager> bookslist)
        {
            using (var connection6 = new MySqlConnection(connectionString))
            {
                connection6.Open();
                string query = "Select * from Books";
                MySqlCommand command = new MySqlCommand(query, connection6);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BooksDBManager BooksDBManager = new BooksDBManager();
                    int isbn = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author = reader.GetString(2);
                    DateOnly datepublished = reader.GetDateOnly(3);
                    string publisher = reader.GetString(4);
                    int numpages = reader.GetInt32(5);
                    string genre = reader.GetString(6);
                    BooksDBManager.SetISBN(isbn);
                    BooksDBManager.SetTitle(title);
                    BooksDBManager.SetAuthor(author);
                    BooksDBManager.SetPublishDate(datepublished);
                    BooksDBManager.SetPublisherName(publisher);
                    BooksDBManager.SetPagesnum(numpages);
                    BooksDBManager.SetGenre(genre);
                    bookslist.Add(BooksDBManager);
                }
                connection6.Close();

            }
        }




        public override void DisplayAvailableBooks(List<BooksDBManager> bookList)
        {

            using (var connection15 = new MySqlConnection(connectionString))
            {
                connection15.Open();
                string query = $"Select * from books WHERE available = 'YES'";
                MySqlCommand command = new MySqlCommand(query, connection15);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BooksDBManager BooksDBManager = new BooksDBManager();
                    int isbn = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author = reader.GetString(2);
                    DateOnly datepublished = reader.GetDateOnly(3);
                    string publisher = reader.GetString(4);
                    int numpages = reader.GetInt32(5);
                    string genre = reader.GetString(6);
                    BooksDBManager.SetISBN(isbn);
                    BooksDBManager.SetTitle(title);
                    BooksDBManager.SetAuthor(author);
                    BooksDBManager.SetPublishDate(datepublished);
                    BooksDBManager.SetPublisherName(publisher);
                    BooksDBManager.SetPagesnum(numpages);
                    BooksDBManager.SetGenre(genre);
                    bookList.Add(BooksDBManager);
                }
                connection15.Close();

            }
        }



        public override void DisplayBorrowedBooks(List<BooksDBManager> bookList)
        {

            using (var connection18 = new MySqlConnection(connectionString))
            {
                connection18.Open();
                string query = $"Select * from books WHERE available = 'NO'";
                MySqlCommand command = new MySqlCommand(query, connection18);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BooksDBManager BooksDBManager = new BooksDBManager();
                    int isbn = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author = reader.GetString(2);
                    DateOnly datepublished = reader.GetDateOnly(3);
                    string publisher = reader.GetString(4);
                    int numpages = reader.GetInt32(5);
                    string genre = reader.GetString(6);
                    BooksDBManager.SetISBN(isbn);
                    BooksDBManager.SetTitle(title);
                    BooksDBManager.SetAuthor(author);
                    BooksDBManager.SetPublishDate(datepublished);
                    BooksDBManager.SetPublisherName(publisher);
                    BooksDBManager.SetPagesnum(numpages);
                    BooksDBManager.SetGenre(genre);
                    bookList.Add(BooksDBManager);
                }
                connection18.Close();

            }
        }

    }
}


