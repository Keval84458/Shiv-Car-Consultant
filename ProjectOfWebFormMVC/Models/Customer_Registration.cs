using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ProjectOfWebFormMVC.Models;
using System.ComponentModel;

namespace ProjectOfWebFormMVC.Models
{
    public class Customer_Registration
    {
        [DisplayName("ID")]
        [Key]
        [Required(ErrorMessage = "**")]
        public int Customer_Id { get; set; }

        [DisplayName("NAME")]
        [Required(ErrorMessage = "**")]
        public string Customer_Name { get; set; }

        [DisplayName("EMAIL")]
        [Required(ErrorMessage = "**")]
        [DataType(DataType.EmailAddress)]
        public string Customer_Email { get; set; }

        [DisplayName("CITY")]
        [Required(ErrorMessage = "**")]
        public string Customer_City { get; set; }

        [DisplayName("GENDER")]
        [Required(ErrorMessage = "**")]
        public string Customer_Gender { get; set; }

        [DisplayName("MOBILE")]
        [Required(ErrorMessage = "**")]
        [DataType(DataType.PhoneNumber)]
        public string Customer_Mobile { get; set; }

        [DisplayName("CAR_NAME")]
        [Required(ErrorMessage = "**")]
        public string Customer_Car_Name { get; set; }


        [DisplayName("CAR_NO")]
        [Required(ErrorMessage = "**")]
        public string Car_No { get; set; }

        [DisplayName("DATE")]
        [Required(ErrorMessage = "**")]
        [DataType(DataType.Date)]
        public string Date { get; set; }


       
    }  
    public class Customer_RegistrationContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


        public List<Customer_Registration> GetCustomer()
        {

            List<Customer_Registration> customer_s = new List<Customer_Registration>();

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select *from CUSTOMER_REG", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Customer_Registration c = new Customer_Registration();
                c.Customer_Id = Convert.ToInt32(dr.GetValue(0).ToString());
                c.Customer_Name = dr.GetValue(1).ToString();
                c.Customer_Email = dr.GetValue(2).ToString();
                c.Customer_City = dr.GetValue(3).ToString();
                c.Customer_Gender = dr.GetValue(4).ToString();
                c.Customer_Mobile = dr.GetValue(5).ToString();
                c.Customer_Car_Name = dr.GetValue(6).ToString();
                c.Car_No = dr.GetValue(7).ToString();
                c.Date = dr.GetValue(8).ToString();
                customer_s.Add(c);
            }
            conn.Close();
            return customer_s;
        }

        public bool AddCustomer(Customer_Registration c)
        {
            if (string.IsNullOrEmpty(c.Customer_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_Email))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_City))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_Gender))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_Mobile))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_Car_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Car_No))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Date))
            {
                return false;
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into CUSTOMER_REG values(@CUSTOMER_NAME,@CUSTOMER_EMIL,@CUSTOMER_CITY,@CUSTOMER_GENDER,@CUSTOMER_MOBILE,@CUSTOMER_CAR_NAME,@CAR_NO,@DATE)", conn);
                cmd.Parameters.AddWithValue("@CUSTOMER_NAME", c.Customer_Name);
                cmd.Parameters.AddWithValue("@CUSTOMER_EMIL", c.Customer_Email);
                cmd.Parameters.AddWithValue("@CUSTOMER_CITY", c.Customer_City);
                cmd.Parameters.AddWithValue("@CUSTOMER_GENDER", c.Customer_Gender);
                cmd.Parameters.AddWithValue("@CUSTOMER_MOBILE", c.Customer_Mobile);
                cmd.Parameters.AddWithValue("@CUSTOMER_CAR_NAME", c.Customer_Car_Name);
                cmd.Parameters.AddWithValue("@CAR_NO", c.Car_No);
                cmd.Parameters.AddWithValue("@DATE", c.Date);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
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


        public bool UpdateCustomer(Customer_Registration c)
        {

            if (string.IsNullOrEmpty(c.Customer_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_Email))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_City))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_Gender))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_Mobile))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Customer_Car_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Car_No))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Date))
            {
                return false;
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("update CUSTOMER_REG set CUSTOMER_NAME=@CUSTOMER_NAME,CUSTOMER_EMAIL=@CUSTOMER_EMAIL,CUSTOMER_CITY=@CUSTOMER_CITY,CUSTOMER_GENDER=@CUSTOMER_GENDER,CUSTOMER_MOBILE=@CUSTOMER_MOBILE,CUSTOMER_CAR_NAME=@CUSTOMER_CAR_NAME,CAR_NO=@CAR_NO,DATE=@DATE where CUSTOMER_ID=@ID ", conn);
                cmd.Parameters.AddWithValue("@ID", c.Customer_Id);
                cmd.Parameters.AddWithValue("@CUSTOMER_NAME", c.Customer_Name);
                cmd.Parameters.AddWithValue("@CUSTOMER_EMAIL", c.Customer_Email);
                cmd.Parameters.AddWithValue("@CUSTOMER_CITY", c.Customer_City);
                cmd.Parameters.AddWithValue("@CUSTOMER_GENDER", c.Customer_Gender);
                cmd.Parameters.AddWithValue("@CUSTOMER_MOBILE", c.Customer_Mobile);
                cmd.Parameters.AddWithValue("@CUSTOMER_CAR_NAME", c.Customer_Car_Name);
                cmd.Parameters.AddWithValue("@CAR_NO", c.Car_No);
                cmd.Parameters.AddWithValue("@DATE", c.Date);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
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

        public bool DeleteCustomer(int Id)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("delete from CUSTOMER_REG where CUSTOMER_ID=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", Id);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
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