using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace LibraryManagementSystem.Components.Pages.Data
{
    public class RentalDBManager : Rentals
    {
        string connectionString = DBConnection.builder.ConnectionString;
        public void IssueAccessISBN(List<int> isbnList)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "Select books_isbn_no from books WHERE available = 'YES'";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int isbn = reader.GetInt32(0);
                        isbnList.Add(isbn);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ReturnAccessISBN(List<int> isbnList)
        {
            try
            {
                int member_id = GetRentalMemberID();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"Select book_isbn_no from rentals WHERE member_id = {member_id}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int isbn = reader.GetInt32(0);
                        isbnList.Add(isbn);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AccessRentalMember(List<int> memberIdList)
        {
            int isbn = GetRentalISBN();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Select Distinct member_id from rentals";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int member_id = reader.GetInt32(0);
                    memberIdList.Add(member_id);
                }
                connection.Close();
            }
        }
        public void AccessMemberID(List<int> memberIdList)
        {

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "Select member_id from members";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int member_id = reader.GetInt32(0);
                    memberIdList.Add(member_id);
                }
                connection.Close();
            }
        }
        public override void IssueBook()
        {
            int isbn = GetRentalISBN();
            int member_id = GetRentalMemberID();
            string borroweddate = GetBorrowDate().ToString("yyyy-MM-dd");
            string returndate = GetReturnDate().ToString("yyyy-MM-dd");
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Insert into rentals Values({isbn},{member_id},'{borroweddate}', '{returndate}'); Update books Set available='NO' WHERE books_isbn_no = {isbn};";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Execute the combined queries
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public override void ReturnBook(int isbn)
        {

            int member_id = GetRentalMemberID();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Delete From rentals where book_isbn_no = {isbn} and member_id = {member_id}; Update books Set available = 'YES' WHERE books_isbn_no = {isbn}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Execute the combined queries
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

        }
        public void DisplayRentals(List<RentalDBManager> rentalList)
        {

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "Select * from rentals";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RentalDBManager rentals = new RentalDBManager();
                    int isbn = reader.GetInt32(0);
                    int member_id = reader.GetInt32(1);
                    DateOnly borrowdate = reader.GetDateOnly(2);
                    DateOnly returndate = reader.GetDateOnly(3);
                    rentals.SetRentalISBN(isbn);
                    rentals.SetRentalMemberID_(member_id);
                    rentals.SetBorrowDate(borrowdate);
                    rentals.SetReturnDate(returndate);
                    rentalList.Add(rentals);


                }
                connection.Close();
            }
        }
    }
}

