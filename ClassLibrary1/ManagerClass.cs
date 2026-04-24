using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace peopleData
{

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }


    }
    public class ManagerClass
    {
        private readonly string _connectionString;
        public ManagerClass(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public List<Person> GetPeople()
        {
            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "select * from people";
            var list = new List<Person>();
            connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Person
                {
                    Id = (int)reader["id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"],
                   
                });
            }
            return list;
        }
        public void DeleteMUltiPeople(List<int>ints)
        {
            using var conn = new SqlConnection(_connectionString);
            
            List<string> parmaerters = new List<string>();
            for (int i=0;i<ints.Count;i++)
            {
                parmaerters.Add($"@id{i}");
            }
            string sql = $"DELETE FROM People WHERE Id IN ({string.Join(",", parmaerters )})";
                using var cmd= new SqlCommand(sql, conn);
            for (int i = 0; i < ints.Count; i++)
            {
                cmd.Parameters.AddWithValue($"@id{i}", ints[i]);
            }
            conn.Open();
            cmd.ExecuteNonQuery();

        }
        public void AddMultiPeople( List<Person>plist)
        {

           using var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "insert into People (FirstName,LastName,Age)values(@FirstName,@LastName,@Age)";
            connection.Open();
            foreach (var p in plist)
            {
                if (true)
                {
                    
                }

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@FirstName",p.FirstName);
                cmd.Parameters.AddWithValue("@LastName", p.LastName);
                cmd.Parameters.AddWithValue("@Age", p.Age);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
