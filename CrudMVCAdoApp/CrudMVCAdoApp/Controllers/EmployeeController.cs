using CrudMVCAdoApp.Models;
using CrudMVCAdoApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVCAdoApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee/GetAllEmpDetails
        public ActionResult GetAllEmpDetails()
        {
            EmployeeRepository EmpRepo = new EmployeeRepository();
            ModelState.Clear();
            return View(EmpRepo.GetAllEmployees());
        }

        // GET: Employee/AddEmployee
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository EmpRepo = new EmployeeRepository();

                    if (EmpRepo.AddEmployee(employee))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/EditEmpDetails/5
        public ActionResult EditEmpDetails(int id)
        {
            EmployeeRepository EmpRepo = new EmployeeRepository();
            return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.EmpID == id));
        }

        // POST: Employee/EditEmpDetails/5
        [HttpPost]
        public ActionResult EditEmpDetails(int id, Employee employee)
        {
            try
            {
                EmployeeRepository EmpRepo = new EmployeeRepository();
                EmpRepo.UpdateEmployee(employee);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                EmployeeRepository EmpRepo = new EmployeeRepository();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}
