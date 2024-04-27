using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ProjectOfWebFormMVC.Models
{
    public class Services
    {
        [Required(ErrorMessage = "**")]
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "**")]
        [DisplayName("CAR NAME")]
        public string Car_Name { get; set; }

        [Required(ErrorMessage = "**")]
        [DisplayName("CAR NO.")]
        public string Car_No { get; set; }

        [Required(ErrorMessage = "**")]
        [DisplayName("OWNER NAME")]
        public string Owner_Name { get; set; }

        [Required(ErrorMessage = "**")]
        [DisplayName("CITY")]
        public string City { get; set; }

    }

    public class ServicesContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Services> GetCarName()
        {
            List<Services> services = new List<Services>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select *from Car_Services", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Services s = new Services();
                s.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                s.Car_Name = dr.GetValue(1).ToString();
                s.Car_No = dr.GetValue(2).ToString();
                s.Owner_Name = dr.GetValue(3).ToString();
                s.City = dr.GetValue(4).ToString();
                services.Add(s);
            }
            conn.Close();
            return services;
        }

        public bool AddCarService(Services s)
        {
            if (string.IsNullOrEmpty(s.Car_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(s.Car_No))
            {
                return false;
            }
            if (string.IsNullOrEmpty(s.Owner_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(s.City))
            {
                return false;
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into Car_Services values(@Car_Name,@Car_No,@Owner_Name,@City)", conn);
                cmd.Parameters.AddWithValue("@Car_Name", s.Car_Name);
                cmd.Parameters.AddWithValue("@Car_No", s.Car_No);
                cmd.Parameters.AddWithValue("@Owner_Name", s.Owner_Name);
                cmd.Parameters.AddWithValue("@City", s.City);
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
        public bool UpdateCarService(Services s)
        {
            if (string.IsNullOrEmpty(s.Car_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(s.Car_No))
            {
                return false;
            }
            if (string.IsNullOrEmpty(s.Owner_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(s.City))
            {
                return false;
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("update Car_Services set Car_Name=@Car_Name,Car_No=@Car_No,Owner_Name=@Owner_Name,City=@City where Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", s.Id);
                cmd.Parameters.AddWithValue("@Car_Name", s.Car_Name);
                cmd.Parameters.AddWithValue("@Car_No", s.Car_No);
                cmd.Parameters.AddWithValue("@Owner_Name", s.Owner_Name);
                cmd.Parameters.AddWithValue("@City", s.City);
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

        public bool DeleteCarService(int Id)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("delete from Car_Services where Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id",Id);           
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