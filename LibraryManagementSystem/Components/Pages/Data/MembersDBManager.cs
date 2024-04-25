using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Components.Pages.Data
{
   
        public class MemberDatabaseManager : Members
        {
            DBConnection database = new DBConnection();
            string connectionString = DBConnection.builder.ConnectionString;
            public override void AddMember()
            {

                string member_id = Convert.ToString(GetMemberID());
                string member_name = GetMemberName();
                string Gender = GetGender();
                string phone_num = GetPhone_num();
                string address = GetAddress();

                using (var connection6 = new MySqlConnection(connectionString))
                {
                    connection6.Open();
                    string query = $"INSERT INTO members Values({member_id},'{member_name}', '{Gender}','{phone_num}','{address}')";
                    MySqlCommand command = new MySqlCommand(query, connection6);
                    command.ExecuteNonQuery();
                    connection6.Close();

                }
            }

            public override void RemoveMember()
            {
                using (var connection7 = new MySqlConnection(connectionString))
                {
                    connection7.Open();
                    string member_id = Convert.ToString(GetMemberID());
                    string member_name = GetMemberName();
                    string query = $"Delete from members Where member_id = {member_id} or member_name = '{member_name}'";
                    MySqlCommand command = new MySqlCommand(query, connection7);
                    command.ExecuteNonQuery();
                    connection7.Close();
                }
            }
            public override void UpdateMember()
            {
                string member_id = Convert.ToString(GetMemberID());
                string member_name = GetMemberName();
                string Gender = GetGender();
                string phone_num = GetPhone_num();
                string address = GetAddress();

                using (var connection8 = new MySqlConnection(connectionString))
                {
                    connection8.Open();
                    string query = $"Update members Set member_name = '{member_name}', member_gender = '{Gender}', phone_number = '{phone_num}', member_address = '{address}' WHERE member_id = {member_id} ";
                    MySqlCommand command = new MySqlCommand(query, connection8);
                    command.ExecuteNonQuery();
                    connection8.Close();
                }

            }
            public override void DisplayMembers(List<MemberDatabaseManager> memberslist)
            {

                using (var connection9 = new MySqlConnection(connectionString))
                {
                    connection9.Open();
                    string query = $"Select * from members";
                    MySqlCommand command = new MySqlCommand(query, connection9);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MemberDatabaseManager members = new MemberDatabaseManager();
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string gender = reader.GetString(2);
                        string phone_num = reader.GetString(3);
                        string address = reader.GetString(4);
                        members.SetMemberID(id);
                        members.SetMemberName(name);
                        members.SetGender(gender);
                        members.SetPhoneNum(phone_num);
                        members.SetAddress(address);
                        memberslist.Add(members);
                    }
                    connection9.Close();

                }
            }
           
        }
    }

