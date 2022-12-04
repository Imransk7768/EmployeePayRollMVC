using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        //private SqlConnection con;
        //public void Connection()
        //{
        //    string connectingString = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=EmpPayRoll";
        //}
        private readonly IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string AddEmployee(EmployeeModel model)
        {
            try
            {
                //Connection();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayRollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spInsertEmpPayroll", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                    cmd.Parameters.AddWithValue("@ProfileImage", model.Profileimage);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@Department", model.Department);
                    cmd.Parameters.AddWithValue("@Salary", model.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", model.StartDate);
                    cmd.Parameters.AddWithValue("@Note", model.Note);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "Emp Data Added Success";
                    }
                    else
                    {
                        return "Emp Data  Added Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateEmployee(EmployeeModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayRollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmpPayroll", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                    cmd.Parameters.AddWithValue("@ProfileImage", model.Profileimage);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@Department", model.Department);
                    cmd.Parameters.AddWithValue("@Salary", model.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", model.StartDate);
                    cmd.Parameters.AddWithValue("@Note", model.Note);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "Emp Data Updated";
                    }
                    else
                    {
                        return "Emp Data Update Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteEmployee(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayRollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmpPayroll", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", id);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "Emp Data Deleted Success";
                    }
                    else
                    {
                        return "Emp Data Deleted Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> empList = new List<EmployeeModel>();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayRollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spGetEmpPayroll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmployeeModel model = new EmployeeModel();

                        model.EmpId = Convert.ToInt32(dr["EmpId"]);
                        model.EmpName = Convert.ToString(dr["EmpName"]);
                        model.Profileimage = Convert.ToString(dr["ProfileImage"]);
                        model.Gender = Convert.ToString(dr["Gender"]);
                        model.Department = Convert.ToString(dr["Department"]);
                        model.Salary = Convert.ToInt32(dr["salary"]);
                        model.StartDate = Convert.ToDateTime(dr["startDate"]);
                        model.Note = Convert.ToString(dr["note"]);

                        empList.Add(model);
                    }
                    con.Close();
                }
                return empList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmployeeModel GetEmpDataById(int? id)
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayRollMVC"]))
                {
                    string sqlQuery = "SELECT * FROM EmpPayroll WHERE EmpId= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        model.EmpId = Convert.ToInt32(dr["EmpId"]);
                        model.EmpName = Convert.ToString(dr["EmpName"]);
                        model.Profileimage = Convert.ToString(dr["ProfileImage"]);
                        model.Gender = Convert.ToString(dr["Gender"]);
                        model.Department = Convert.ToString(dr["Department"]);
                        model.Salary = Convert.ToInt32(dr["salary"]);
                        model.StartDate = Convert.ToDateTime(dr["startDate"]);
                        model.Note = Convert.ToString(dr["note"]);
                    }
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
