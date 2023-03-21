using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    class UserDAL
    {
        public void AddPerson(UserRegistration newUser)
        {
            
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramFirstName = new SqlParameter("@FirstName", newUser.FirstName);
                SqlParameter paramLastName = new SqlParameter("@LastName", newUser.LastName);
                SqlParameter paramUsername = new SqlParameter("@Username", newUser.user.Username);
                SqlParameter paramEmail = new SqlParameter("@Email", newUser.user.Email);
                SqlParameter paramPassword = new SqlParameter("@Password", newUser.user.Password);

                
                cmd.Parameters.Add(paramFirstName);
                cmd.Parameters.Add(paramLastName);
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPassword);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<UserRegistration> GetAllPersons()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllPers", con);
                ObservableCollection<UserRegistration> result = new ObservableCollection<UserRegistration>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserRegistration p = new UserRegistration();
                    p.user.UserID= (Int64)(reader[0]);
                    p.FirstName = (reader.GetString(1));
                    p.LastName = (reader.GetString(2));
                    p.user.Username = (reader.GetString(3));
                    p.user.Password = (reader.GetString(4));
                    p.user.Email = (reader.GetString(5));
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public bool LogIntoAccount(UserLogin user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("LoginValidation", con);
                ObservableCollection<UserLogin> result = new ObservableCollection<UserLogin>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUsername = new SqlParameter("@username", user.Username);
                SqlParameter paramPassword = new SqlParameter("@password", user.Password);
                SqlParameter paramUserType = new SqlParameter("@usertype", user.UserType);
                SqlParameter paramReturn = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                paramReturn.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(paramReturn);
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);
                cmd.Parameters.Add(paramUserType);
                con.Open();
                cmd.ExecuteNonQuery();
                int returnValue = (int)paramReturn.Value;
                if (returnValue == 0)
                    return true;
            }
         
            return false;
        }
    }
}
