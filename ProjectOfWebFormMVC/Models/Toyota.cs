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
using System.ComponentModel;

namespace ProjectOfWebFormMVC.Models
{
    public class Toyota
    {
        [Required(ErrorMessage = "**")]
        [DisplayName("ID")]
        [Key]
        public int Car_Id { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("COMPONY")]
        public string Compony_Name { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("NAME")]
        public string Car_Name { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("NO.")]
        public string Car_No { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("FUAL TYPE")]
        public string Car_Model { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("OWNER")]
        public string Owner_Name { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("YEAR")]
        public int Model_Year { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("CITY")]
        public string City { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("PRICE")]
        public string Car_Price { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("DATE")]
        [DataType(DataType.Date)]
        public string Date { get; set; }
    }

    public class ToyotaContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Toyota> GetCars()
        {
            List<Toyota> cars = new List<Toyota>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select *from CAR_Reg where COMPONY_NAME='TOYOTA'", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Toyota car = new Toyota();
                car.Car_Id = Convert.ToInt32(dr.GetValue(0).ToString());
                car.Compony_Name = dr.GetValue(1).ToString();
                car.Car_Name = dr.GetValue(2).ToString();
                car.Car_No = dr.GetValue(3).ToString();
                car.Car_Model = dr.GetValue(4).ToString();
                car.Owner_Name = dr.GetValue(5).ToString();
                car.Model_Year = Convert.ToInt32(dr.GetValue(6).ToString());
                car.City = dr.GetValue(7).ToString();
                car.Car_Price = dr.GetValue(8).ToString();
                car.Date = dr.GetValue(9).ToString();
                cars.Add(car);
            }
            conn.Close();
            return cars;
        }

        public bool UpdateCars(Toyota c)
        {

            if (string.IsNullOrEmpty(c.Compony_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Car_Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Car_No))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Car_Model))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Owner_Name))
            {
                return false;
            }
            if (c.Model_Year == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.City))
            {
                return false;
            }
            if (string.IsNullOrEmpty(c.Car_Price))
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
                SqlCommand cmd = new SqlCommand("update CAR_Reg set CAR_NAME=@CAR_NAME,CAR_NO=@CAR_NO,CAR_MODEL=@CAR_MODEL,OWNER_NAME=@OWNER_NAME,YEAR=@YEAR,CITY=@CITY,CAR_PRICE=@CAR_PRICE,DATE=@DATE where CAR_ID=@CAR_ID ", conn);
                cmd.Parameters.AddWithValue("@CAR_ID", c.Car_Id);
                cmd.Parameters.AddWithValue("@CAR_NAME", c.Car_Name);
                cmd.Parameters.AddWithValue("@CAR_NO", c.Car_No);
                cmd.Parameters.AddWithValue("@CAR_MODEL", c.Car_Model);
                cmd.Parameters.AddWithValue("@OWNER_NAME", c.Owner_Name);
                cmd.Parameters.AddWithValue("@YEAR", c.Model_Year);
                cmd.Parameters.AddWithValue("@CITY", c.City);
                cmd.Parameters.AddWithValue("@CAR_PRICE", c.Car_Price);
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

        public bool DeleteCars(int Id)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("delete from CAr_Reg where CAR_ID=@Id", conn);
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