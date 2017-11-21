using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace DBTest
{
    class DataAccess
    {
        IDbConnection con = new SqlConnection(Database.conVal("DBTest"));

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            users = con.Query<User>("Select * From Users").ToList();
            return users;
        }

        public void InsertUser(string name, int age)
        {
            List<User> user = new List<User>();

            user.Add(new User { Name = name, Age = age });
            con.Execute("Insert into Users(Name,Age) Values(@Name, @Age)", user);
        }

        public void UpdateUser(string name, int age, int id)
        {
            List<User> users = new List<User>();

            users.Add(new User { Name = name, Age = age, Id = id });
            con.Execute("Update Users Set Name=@Name, Age=@Age where Id=@Id", users);
        }

        public void DeleteUser(int id)
        {
            List<User> user = new List<User>();

            user.Add(new User { Id = id });
            con.Execute("Delete from Users where Id=@Id", user);
        }
    }
}
