using System.Collections.Generic;
using BusinessLayer.Interfaces;
using RepositoryLayer.Interfaces;
using CommonLayer.ResponseModel;
using System;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        
        IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
           
        }
        public List<EmployeeModel> GetAllEployeesData()
        {
            try
            {
                return employeeRL.GetAllEmployeeDetail();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EmployeeModel RegisterEmployeeData(EmployeeModel employee)
        {
            try
            {
                //var stream = file.OpenReadStream();
                //var name = file.FileName;
                //Account account = new Account("devjs8e7v", "217619793785761", "t8nmfVwKgMJciXM8dP_B2C5UK90");
               // Cloudinary cloudinary = new Cloudinary(account);
               // var uploadParams = new ImageUploadParams()
               // {
                 //   File = new FileDescription(name, stream)
               // };
               // ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
               // employee.ProfileImage = uploadResult.Url.ToString();
                return employeeRL.RegisterEmployeeData(employee);

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public EmployeeModel UpdateEmployeeData(EmployeeModel employee, int ID)
        {
            try
            {
                return employeeRL.UpdateEmployeeData(employee, ID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public EmployeeModel ReturnSpecificRecord(int ID)
        {
            try
            {
                return employeeRL.ReturnSpecificRecord(ID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public EmployeeModel DeleteSpecificEmployeeData(int ID)
        {
            try
            {
                return employeeRL.DeleteSpecificEmployeeData(ID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}