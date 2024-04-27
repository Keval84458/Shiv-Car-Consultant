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
    public class SoldCar
    {
        [Required(ErrorMessage ="**")]
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("CAR NAME")]
        public string Car_Name { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("CAR NO")]
        public string Car_No { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("CUSTO. Name")]
        public string Customer_Name { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("OWNER NAME")]
        public string Owner_Name { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("MOBILE")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("DATE")]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        [Required(ErrorMessage = "**")]
        [DisplayName("CITY")]
        public string City { get; set; }
    }

    public class SoldCarContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<SoldCar> GetCars()
        {
            List<SoldCar> soldCars = new List<SoldCar>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select *from Sold_Cars", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                SoldCar s = new SoldCar();
                s.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                s.Car_Name = dr.GetValue(1).ToString();
                s.Car_No = dr.GetValue(2).ToString();
                s.Customer_Name = dr.GetValue(3).ToString();
                s.Owner_Name = dr.GetValue(4).ToString();
                s.Mobile = dr.GetValue(5).ToString();
                s.Date = dr.GetValue(6).ToString();
                s.City = dr.GetValue(7).ToString();
                soldCars.Add(s);
            }
            conn.Close();
            return soldCars;
        }
        public bool AddSoldCars(SoldCar s)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("insert into Sold_Cars values(@Car_Name,@Car_No,@Customer_Name,@Owner_Name,@Mobile,@Date,@City)", conn);
            cmd.Parameters.AddWithValue("@Car_Name", s.Car_Name);
            cmd.Parameters.AddWithValue("@Car_No", s.Car_No);
            cmd.Parameters.AddWithValue("@Customer_Name", s.Customer_Name);
            cmd.Parameters.AddWithValue("@Owner_Name", s.Owner_Name);
            cmd.Parameters.AddWithValue("@Mobile", s.Mobile);
            cmd.Parameters.AddWithValue("@Date", s.Date);
            cmd.Parameters.AddWithValue("@City", s.City);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if(a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            conn.Close();
        }


        public bool UpdateSoldCars(SoldCar s)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("update Sold_Cars set Car_Name=@Car_Name,Car_No=@Car_No,Customer_Name=@Customer_Name,Owner_Name=@Owner_Name,Mobile=@Mobile,Date=@Date,City=@City where Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id",s.Id);
            cmd.Parameters.AddWithValue("@Car_Name", s.Car_Name);
            cmd.Parameters.AddWithValue("@Car_No", s.Car_No);
            cmd.Parameters.AddWithValue("@Customer_Name", s.Customer_Name);
            cmd.Parameters.AddWithValue("@Owner_Name", s.Owner_Name);
            cmd.Parameters.AddWithValue("@Mobile", s.Mobile);
            cmd.Parameters.AddWithValue("@Date", s.Date);
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

        public bool DeleteSoldCars(int Id)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("delete from Sold_Cars where Id=@Id", conn);
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