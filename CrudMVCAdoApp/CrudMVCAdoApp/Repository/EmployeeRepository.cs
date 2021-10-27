using CrudMVCAdoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudMVCAdoApp.Repository
{
    public class EmployeeRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeContext"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddEmployee(Employee obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            connection();
            List<Employee> EmpList = new List<Employee>();
            SqlCommand com = new SqlCommand("GetEmployees", con);

            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new Employee
                    {
                        EmpID = Convert.ToInt32(dr["EmpID"]),
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
                        Address = Convert.ToString(dr["Address"]),
                        Age = Convert.ToInt32(dr["Age"]),
                        Rank = Convert.ToInt32(dr["Rank"]),
                        IsActive = Convert.ToBoolean(dr["IsActive"]),
                        Description = Convert.ToString(dr["Description"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        Create = Convert.ToDateTime(dr["Create"])
                    }
                );
            }
            return EmpList;
        }

        public bool UpdateEmployee(Employee obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpID", obj.EmpID);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteEmployee(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpID", Id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}