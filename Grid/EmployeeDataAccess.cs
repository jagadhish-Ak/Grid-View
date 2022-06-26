using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grid
{
    public class Employee2
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
    public class EmployeeDataAccess
    {
        public static List<Employee2> GetAllEmployees(int DepartmentId)
        {
            List<Employee2> listEmployees = new List<Employee2>();

            string CS = ConfigurationManager.ConnectionStrings["demodbconn10"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblEmployee where DeptId = @DepartmentId", con);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@DepartmentId";
                parameter.Value = DepartmentId;
                cmd.Parameters.Add(parameter);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee2 employee = new Employee2();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.EmployeeName = rdr["Name"].ToString();

                    listEmployees.Add(employee);
                }
            }

            return listEmployees;
        }
    }
}