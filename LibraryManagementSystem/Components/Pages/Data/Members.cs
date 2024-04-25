using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Components.Pages.Data
{
  
        public abstract class Members
        {
            private int Member_Id;
            private string Member_Name;
            private string Gender;
            private string Phone_num;
            private string Address;
            public int GetMemberID()
            {
                return Member_Id;
            }
            public void SetMemberID(int member_Id)
            {
                this.Member_Id = member_Id;
            }
            public string GetMemberName()
            {
                return Member_Name;
            }
            public void SetMemberName(string member_Name)
            {
                this.Member_Name = member_Name;
            }
            public string GetGender()
            {
                return Gender;
            }
            public void SetGender(string gender)
            {
                this.Gender = gender;
            }
            public string GetPhone_num()
            {
                return Phone_num;
            }
            public void SetPhoneNum(string phone_num)
            {
                this.Phone_num = phone_num;
            }
            public string GetAddress()
            {
                return Address;
            }
            public void SetAddress(string address)
            {
                this.Address = address;
            }
            public abstract void AddMember();
            public abstract void RemoveMember();
            public abstract void UpdateMember();

            public abstract void DisplayMembers(List<MemberDatabaseManager> memberslist);

        }
}
