using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CommonLayer.ResponseModel;
using EmployeeDetailModel = CommonLayer.ResponseModel.EmployeeDetailModel;

namespace RepositoryLayer.Service
{
    public class EmployeeRL : IEmployeeRL                            //Inheriting IEmployeeRL into Class EmployeeRL
    {

        private static string connectionString = "Data Source=DESKTOP-OKP25QH;Initial Catalog=employeeDetails;Integrated Security=SSPI";
        public EmployeeDetailModel employeeModel = new EmployeeDetailModel();
        
        public List<EmployeeDetailModel> GetAllEmployeeRecords()
        {
         
            List<EmployeeDetailModel> lists = new List<EmployeeDetailModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string Spname = "dbo.Er_GetAllEmployeedetails";
                using (connection)
                {
                       
                        //define the SqlCommand Object
                        SqlCommand cmd = new SqlCommand(Spname, connection);
                        //Commandtype contain the storedprocedure must be run
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        //Sqlreader provide way to reading and execute reader send sql statment to connection 
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();

                        //check if there are records
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                            //insert into a list
                            lists.Add(new EmployeeDetailModel
                            {

                                id = sqlDataReader.GetInt32(0),
                                Name = sqlDataReader.GetString(1),
                                Gender = Convert.ToChar(sqlDataReader.GetString(2)),
                                image = sqlDataReader.GetString(3),
                                Salary = sqlDataReader.GetInt32(4),
                                startDate = sqlDataReader.GetDateTime(5),
                                Notes = sqlDataReader.GetString(6),
                                DeptID = sqlDataReader.GetInt32(7),
                                Department1 = sqlDataReader.GetString(8),
                                Department2 = sqlDataReader.GetString(9),
                                Department3 = sqlDataReader.GetString(10)


                            }); ; ; ;
                            }

                        }

                        //Close Data Reader
                        sqlDataReader.Close();
                        connection.Close();
                }
                
                return lists;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        
        public EmployeeDetailModel GetEmployee(int id)
        {
            

            try
            {
               
                SqlConnection connection = new SqlConnection(connectionString);
                string spName = @"dbo.[Er_GetoneEmployeedetails]";
                    using (connection)
                    {
                       
                        //define the SqlCommand Object
                        SqlCommand cmd = new SqlCommand(spName, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id ", id);
                        connection.Open();
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();

                        //check if there r records
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                            employeeModel.id = sqlDataReader.GetInt32(0);
                            employeeModel.Name = sqlDataReader.GetString(1);
                            employeeModel.Gender = Convert.ToChar(sqlDataReader.GetString(2));
                            employeeModel.image = sqlDataReader.GetString(3);
                            employeeModel.Salary = sqlDataReader.GetInt32(4);
                            employeeModel.startDate = sqlDataReader.GetDateTime(5);
                            employeeModel.Notes = sqlDataReader.GetString(6);
                            employeeModel.DeptID = sqlDataReader.GetInt32(7);
                            employeeModel.Department1 = sqlDataReader.GetString(8);
                            employeeModel.Department2 = sqlDataReader.GetString(9);
                            employeeModel.Department3 = sqlDataReader.GetString(10);

                        }
                        }

                        //Close Data Reader
                        sqlDataReader.Close();
                        connection.Close();
                    }
                return employeeModel;
                
                
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        
        public bool DeleteEmployee(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                
                
                    string spName = @"dbo.[DeleteEmployeeDetail]";
                    using (connection)
                    {

                        SqlCommand cmd = new SqlCommand(spName, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id ", id);
                        connection.Open();

                        SqlDataReader sqlDataReader = cmd.ExecuteReader();

                        if (sqlDataReader.HasRows == false)
                        {
                            while (sqlDataReader.Read())
                            {
                                employeeModel.id = sqlDataReader.GetInt32(0);
                                employeeModel.Name = sqlDataReader.GetString(1);
                                employeeModel.Gender = Convert.ToChar(sqlDataReader.GetString(2));
                                employeeModel.image = sqlDataReader.GetString(3);
                                employeeModel.Salary = sqlDataReader.GetInt32(4);
                                employeeModel.startDate = sqlDataReader.GetDateTime(5);
                                employeeModel.Notes = sqlDataReader.GetString(6);
                                employeeModel.DeptID = sqlDataReader.GetInt32(7);
                                employeeModel.Department1 = sqlDataReader.GetString(8);
                                employeeModel.Department2 = sqlDataReader.GetString(9);
                                employeeModel.Department3 = sqlDataReader.GetString(10);
                        }
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                        sqlDataReader.Close();
                        connection.Close();
                    }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public bool UpdateEmployee(EmployeeDetailModel employeeModel,int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string spName = @"dbo.[Er_Getupdatedeatils]";
                    using (connection)
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand(spName, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id ", employeeModel.id);
                        cmd.Parameters.AddWithValue("@name ", employeeModel.Name);
                        cmd.Parameters.AddWithValue("@gender ", employeeModel.Gender);
                        cmd.Parameters.AddWithValue("@image", employeeModel.image);
                        cmd.Parameters.AddWithValue("@salry ", employeeModel.Salary);
                        cmd.Parameters.AddWithValue("@startdate ", employeeModel.startDate);
                        cmd.Parameters.AddWithValue("@note ", employeeModel.Notes);
                        cmd.Parameters.AddWithValue("@Department1", employeeModel.Department1);
                        cmd.Parameters.AddWithValue("@Department2", employeeModel.Department2);
                        cmd.Parameters.AddWithValue("@Department3", employeeModel.Department3);
                        cmd.Parameters.AddWithValue("@param", employeeModel.param);

                        var result = cmd.ExecuteNonQuery();
                        if (result != 0)
                        {
                            return true;


                        }

                        else
                        {
                            return false;


                        }

                        //Close Data Reader
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public EmployeeDetailModel RegisterEmployee(EmployeeDetailModel employeeModel)
        {
           

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string spName = @"dbo.[AddEmployeeDetail]";
                    using (connection)
                    {

                        SqlCommand cmd = new SqlCommand(spName, connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                    
                        cmd.Parameters.AddWithValue("@EmpName", employeeModel.Name);
                        cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                        cmd.Parameters.AddWithValue("@image", employeeModel.image);
                        cmd.Parameters.AddWithValue("@salary", employeeModel.Salary);
                        cmd.Parameters.AddWithValue("@startdate", employeeModel.startDate);
                        cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
                        cmd.Parameters.AddWithValue("@department1", employeeModel.Department1);
                        cmd.Parameters.AddWithValue("@department2", employeeModel.Department2);
                        cmd.Parameters.AddWithValue("@department3", employeeModel.Department3);

                        connection.Open();

                        SqlDataReader sqlDataReader = cmd.ExecuteReader();


                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                
                                employeeModel.Name = sqlDataReader.GetString(0);
                                employeeModel.Gender = Convert.ToChar(sqlDataReader.GetString(1));
                                employeeModel.image = sqlDataReader.GetString(2);
                                employeeModel.Salary = sqlDataReader.GetInt32(3);
                                employeeModel.startDate = sqlDataReader.GetDateTime(4);
                                employeeModel.Notes = sqlDataReader.GetString(5);
                                employeeModel.DeptID = sqlDataReader.GetInt32(6);
                                employeeModel.Department1 = sqlDataReader.GetString(7);
                                employeeModel.Department2 = sqlDataReader.GetString(8);
                                employeeModel.Department3 = sqlDataReader.GetString(9);


                            }
                        }


                        sqlDataReader.Close();
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return employeeModel;
        }


    }

}


