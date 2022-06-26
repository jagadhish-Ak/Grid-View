using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grid
{
     public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Employee2> Employees
        {
            get
            {
                return EmployeeDataAccess.GetAllEmployees(this.DepartmentId);
            }
        }
    }

    public class DepartmentLayer
    {
        public static List<Department> GetAllDepartmentsandEmployees()
        {
            List<Department> listDepartments = new List<Department>();

            string CS = ConfigurationManager.ConnectionStrings["demodbconn10"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblDepartment", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Department department = new Department();
                    department.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                    department.DepartmentName = rdr["Name"].ToString();

                    listDepartments.Add(department);
                }
            }

            return listDepartments;
        }
    }
}