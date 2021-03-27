using CommonLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Service;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL                            //This Interface IEmployeeBL is connected to Controller to avoid the 
    {                                                       //implementation 
                                                            //Interface is created for dependancy injection

        public EmployeeDetailModel GetEmployee(int id);

        public List<EmployeeDetailModel> GetAllEmployeeRecords();

        public bool DeleteEmployee(int id);

        public bool UpdateEmployee(EmployeeDetailModel employeeDetailModel, int id);

        public EmployeeDetailModel RegisterEmployee(EmployeeDetailModel employeeDetailModel);

    }


}
