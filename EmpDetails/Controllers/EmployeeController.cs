using BusinessLayer.Interface;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        IEmployeeBL employeeBL;

        public EmployeeController(IEmployeeBL employeeBL)                           //Constructor n passing an object to controller to access Business layer
        {
            this.employeeBL = employeeBL;
        }


        [HttpGet]                                                                    //Creating a Get Api
        public IActionResult GetAllEmployeeRecords()                                        //Here return type represents the result of an action method
        {
            try
            {                                                                                           //throw exception
                List<EmployeeDetailModel> result = this.employeeBL.GetAllEmployeeRecords();                    //getting the data from BusinessLayer
                return this.Ok(new { Success = true, Message = "Get operation is sucessful retrive all the data ", Data = result });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpGet("{id}")]                                                                    //Creating a Get Api
        public IActionResult GetEmployee(int id)                                        //Here return type represents the result of an action method
        {
            try
            {                                                                                           //throw exception
                EmployeeDetailModel result = employeeBL.GetEmployee(id);                    //getting the data from BusinessLayer
                return this.Ok(new { Success = true, Message = "Get operation Successful retrive particular id data", Data = result });   //(smd format)    //this.Ok returns the data in json format
            }

            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }



        [HttpDelete("{id}")]                                                                    //Creating a delete Api
        public IActionResult DeleteRecord(int id)                                        //Here return type represents the result of an action method
        {
            try
            {
                if (ModelState.IsValid)
                {

                    bool result = this.employeeBL.DeleteEmployee(id);                   //getting the data from BusinessLayer
                    if (result != false)
                    {
                        return this.Ok(new { Success = true, Message = "Delete Employee Record Successfully " });   //(smd format)    //this.Ok returns the data in json format
                    }
                    else
                    {
                        return this.BadRequest(new { Success = false, Message = "Delete  Employee Record Unsuccessfully" });
                    }
                }

                else
                {
                    throw new Exception("Model is not valid");
                }

            }

            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }

        }




        [HttpPost("Register")]                                                                    //Creating a Post Api
        public IActionResult RegisterRecord(EmployeeDetailModel employeeDetailModel)                                        //Here return type represents the result of an action method
        {
            try
            {
                if (ModelState.IsValid)
                {

                    EmployeeDetailModel result = this.employeeBL.RegisterEmployee(employeeDetailModel);                   //getting the data from BusinessLayer
                    if (result != null)
                    {
                        return this.Ok(new { Success = true, Message = "Register Employee Successfully" });   //(smd format)    //this.Ok returns the data in json format
                    }
                    else
                    {
                        return this.BadRequest(new { Success = false, Message = "Register Employee Unsuccessfully" });
                    }
                }

                else
                {
                    throw new Exception("Model is not valid");
                }

            }

            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }


        [HttpPut("{id}")]                                                                    //Creating a Post Api
        public IActionResult UpdateEmployee(EmployeeDetailModel employeeDetailModel, int id)                                        //Here return type represents the result of an action method
        {

            try
            {                                                                                           //throw exception
                bool result = employeeBL.UpdateEmployee(employeeDetailModel, id);                    //getting the data from BusinessLayer
                return this.Ok(new { Success = true, Message = "Put operation Successful Update particular id data" });//(smd format)    //this.Ok returns the data in json format

            }

            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }


    }
}
