using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.ResponseModel;
using BusinessLayer.Interface;

namespace BusinessLayer.Service
{
    public class EmployeeBLcs : IEmployeeBL
    {
        IEmployeeRL employeeRL;
        public EmployeeBLcs(IEmployeeRL employeeRL)                      //Constructor n passing an object to IEmployeeBL
        {                                                              //to get an access of IEmployeeRL
            this.employeeRL = employeeRL;
        }



        public List<EmployeeDetailModel> GetAllEmployeeRecords()
        {
            try
            {

                return this.employeeRL.GetAllEmployeeRecords();                 //throw exceptions
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

                return this.employeeRL.GetEmployee(id);                 //throw exceptions
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

                return this.employeeRL.DeleteEmployee(id);                 //throw exceptions
            }

            catch (Exception e)
            {
                throw e;
            }
        }


        public EmployeeDetailModel RegisterEmployee(EmployeeDetailModel employeeDetailModel)
        {
            try
            {

                return this.employeeRL.RegisterEmployee(employeeDetailModel);                 //throw exceptions
            }

            catch (Exception e)
            {
                throw e;
            }
        }


        public bool UpdateEmployee(EmployeeDetailModel employeeDetailModel, int id)
        {
            try
            {

                return this.employeeRL.UpdateEmployee(employeeDetailModel, id);                 //throw exceptions
            }

            catch (Exception e)
            {
                throw e;
            }
        }





    }
}
