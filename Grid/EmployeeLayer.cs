using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grid
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string city { get; set; }
    }
    public class EmployeeLayer
    {
        public static void DeleteEmployees(List<string> EmployeeIds)
        {
            string CS = ConfigurationManager.ConnectionStrings["demoConnectionString10"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                List<string> parameters = EmployeeIds.Select((s, i) => "@Parameter" + i.ToString()).ToList();
                string inClause = string.Join(",", parameters);
                string deleteCommandText = "Delete from tblEmployee1 where EmployeeId IN (" + inClause + ")";
                SqlCommand cmd = new SqlCommand(deleteCommandText, con);

                for (int i = 0; i < parameters.Count; i++)
                {
                    cmd.Parameters.AddWithValue(parameters[i], EmployeeIds[i]);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listEmployees = new List<Employee>();

            string CS = ConfigurationManager.ConnectionStrings["demoConnectionString10"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblEmployee1", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.city = rdr["City"].ToString();

                    listEmployees.Add(employee);
                }
            }

            return listEmployees;
        }
    }
        public class EmployeeDataAccessLayer
        {
            // Replace square brackets with angular brackets
            public static List<Employee> GetAllEmployees(string sortColumn)
            {
                // Replace square brackets with angular brackets
                List<Employee> listEmployees = new List<Employee>();

                string CS = ConfigurationManager.ConnectionStrings["demodbconn10"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string sqlQuery = "Select * from tblEmployee1";

                    if (!string.IsNullOrEmpty(sortColumn))
                    {
                        sqlQuery += " order by " + sortColumn;
                    }

                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.city = rdr["City"].ToString();

                        listEmployees.Add(employee);
                    }
                }

                return listEmployees;
            }
        }
    }