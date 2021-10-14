using CODEFIRST_ASP.NET.DAL;
using CODEFIRST_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CODEFIRST_ASP.NET.Controllers
{
    public class ContractController : Controller
    {
        private readonly EmployeeContext _dbContext;

        public ContractController()
        {
            this._dbContext = new EmployeeContext();
        }
        // GET: Contract
        public ActionResult Index()
        {
            var contractsList = this._dbContext.Contract.ToList();
            return View(contractsList);
        }

        public ActionResult Create()
        {
            PopulateEmployeesDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractID,Contents,ContractType,SignDate,EmpId,Description,Create,CreatedBy")] Contract contract)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Contract.Add(contract);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateEmployeesDropDownList(contract.EmpID);
            return View(contract);
        }

        // GET: Contract/Edit/5
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = _dbContext.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            PopulateEmployeesDropDownList(contract.EmpID);
            return View(contract);
        }

        // POST: Contact/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contractToUpdate = _dbContext.Contract.Find(id);
            if (TryUpdateModel(contractToUpdate, "",
               new string[] { "ContractID", "Contents", "ContractType", "SignDate", "EmpId", "Description", "Create", "CreatedBy" }))
            {
                try
                {
                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateEmployeesDropDownList(contractToUpdate.EmpID);
            return View(contractToUpdate);
        }

        // GET: Contract/Delete/5
        public ActionResult Delete(String id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Contract contract = _dbContext.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(String id)
        {
            try
            {
                Contract contract = _dbContext.Contract.Find(id);
                _dbContext.Contract.Remove(contract);
                _dbContext.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        private void PopulateEmployeesDropDownList(object selectedEmployee = null)
        {
            var employeesQuery = from d in _dbContext.Employee
                                 orderby d.Name
                                 select d;
            ViewBag.EmpID = new SelectList(employeesQuery, "EmpID", "Name", selectedEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}