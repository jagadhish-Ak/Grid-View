using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grid
{
    public class Employee1
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
    }
    public class EmployeeDataLayer
    {
        public static List<Employee1> GetAllEmployees()
        {
            List<Employee1> listEmployees = new List<Employee1>();

            string CS = ConfigurationManager.ConnectionStrings["demodbconn10"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblEmployee2", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee1 employee = new Employee1();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.Photo = rdr["PhotoPath"].ToString();

                    listEmployees.Add(employee);
                }
            }

            return listEmployees;
        }
    }
}