using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Components.Pages.Data
{

        public abstract class Rentals
        {

            private int isbn { get; set; }
            private int member_id { get; set; }
            private DateOnly borroweddate { get; set; }
            private DateOnly returndate { get; set; }
            string connectionString = DBConnection.builder.ConnectionString;
            public abstract void IssueBook();
            public abstract void ReturnBook(int isbn);
            public int GetRentalISBN()
            {
                return isbn;
            }
            public void SetRentalISBN(int isbn)
            {
                this.isbn = isbn;
            }
            public int GetRentalMemberID()
            {
                return member_id;
            }
            public void SetRentalMemberID_(int member_id)
            {
                this.member_id = member_id;
            }
            public DateOnly GetBorrowDate()
            {
                return borroweddate;
            }
            public void SetBorrowDate(DateOnly borrow_date)
            {
                this.borroweddate = borrow_date;
            }
            public DateOnly GetReturnDate()
            {
                return returndate;
            }
            public void SetReturnDate(DateOnly returndate)
            {
                this.returndate = returndate;
            }

        }
    }

