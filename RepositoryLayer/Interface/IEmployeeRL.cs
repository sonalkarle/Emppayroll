using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public List<EmployeeDetailModel> GetAllEmployeeRecords();
        public EmployeeDetailModel GetEmployee(int id);
        public bool DeleteEmployee(int id);
        public bool UpdateEmployee(EmployeeDetailModel employeeDetailModel, int id);
        public EmployeeDetailModel RegisterEmployee(EmployeeDetailModel employeeDetailModel);


    }


}