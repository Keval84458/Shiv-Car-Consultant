
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ProjectOfWebFormMVC.Models;

namespace ProjectOfWebFormMVC.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Please enter Valid Username...")]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter Valid Password...")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class LoginContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public bool CheckData(Login l)
        {
            if(string.IsNullOrEmpty(l.Username))
            {
                return false;
            }
            if (string.IsNullOrEmpty(l.Password))
            {
                return false;
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("select *from Login where Username=@Username AND Password=@Password", conn);
                cmd.Parameters.AddWithValue("@Username", l.Username);
                cmd.Parameters.AddWithValue("@Password", l.Password);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    return true;
                    
                }
                else
                {
                    return false;
                }
                conn.Close();

            }


        }
    }
}