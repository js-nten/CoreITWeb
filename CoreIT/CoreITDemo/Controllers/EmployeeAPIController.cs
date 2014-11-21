using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CoreITDemo.Models;
using CoreITDemo.ViewModels;

namespace CoreITDemo.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        private CoreITDemoContext db = new CoreITDemoContext();

        // GET api/Employeeapi
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            //return db.Employees.AsEnumerable()

            //IEnumerable<EmployeeDTO> emp = (from e in db.Employees
            //                                join s in db.Salaries on e.EmpId equals s.EmpId into ljresults
            //                                from rs in ljresults
            //                                select new EmployeeDTO()
            //                                {
            //                                    EmpId = e.EmpId,
            //                                    Firstname = e.Firstname,
            //                                    Lastname = e.Lastname,
            //                                    ImmigrationStatus = Enum.GetName(typeof(ImmigrationStatus), e.ImmigrationStatus),
            //                                    Salary = (decimal?)rs.PerW2,
            //                                    HireDate = e.HireDate
            //                                }).ToList();
            var emp = (from e in db.Employees
                       join a in db.Address on e.EmpId equals a.EntityId
                       join s in db.Salaries on e.EmpId equals s.EmpId into ljresults
                       from rs in ljresults.DefaultIfEmpty()
                       select new
                       {
                           e.EmpId,
                           e.Firstname,
                           e.Lastname,
                           e.ImmigrationStatus,
                           PerW2 = (decimal?)rs.PerW2,
                           e.HireDate,
                           SalaryEffectiveDate = (DateTime?)rs.ExpirationDate,
                           a.Address1,
                           a.Address2,
                           a.City,
                           a.StateOrProvince,
                           a.PostalCode,
                           a.EmailId,
                           a.IsCurrent
                       }).ToList();

            IEnumerable<EmployeeDTO> empDTO = from e in emp
                                              where (e.SalaryEffectiveDate == null || e.SalaryEffectiveDate.Value.CompareTo(DateTime.Today) > 0) && e.IsCurrent == true
                                              select new EmployeeDTO()
                                              {
                                                  EmpId = e.EmpId,
                                                  Firstname = e.Firstname,
                                                  Lastname = e.Lastname,
                                                  ImmigrationStatus = Enum.GetName(typeof(ImmigrationStatus), e.ImmigrationStatus),
                                                  Salary = e.PerW2,
                                                  HireDate = e.HireDate,
                                                  Address1 = e.Address1,
                                                  Address2 = e.Address2,
                                                  City = e.City,
                                                  StateOrProvince = e.StateOrProvince,
                                                  PostalCode = e.PostalCode,
                                                  EmailId = e.EmailId
                                              };

            return empDTO;
        }

        // GET api/Employeeapi/5
        public EmployeeDTO GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);

            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new EmployeeDTO()
            {
                EmpId = employee.EmpId,
                Firstname = employee.Firstname,
                Lastname = employee.Lastname,
                ImmigrationStatus = Enum.GetName(typeof(ImmigrationStatus), employee.ImmigrationStatus)
            };


        }

        // PUT api/Employeeapi/5
        public HttpResponseMessage PutEmployee(int id, EmployeeDTO empDTO)
        {
            if (ModelState.IsValid && id == empDTO.EmpId)
            {
                var employee = new Employee()
                                {
                                    EmpId = empDTO.EmpId,
                                    Firstname = empDTO.Firstname,
                                    Lastname = empDTO.Lastname,
                                    ImmigrationStatus = (ImmigrationStatus)Enum.Parse(typeof(ImmigrationStatus), empDTO.ImmigrationStatus)

                                };
                
                db.Entry(employee).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Employeeapi
        public HttpResponseMessage PostEmployee([Bind(Exclude = "EmpId")] EmployeeDTO empDTO)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Firstname = empDTO.Firstname,
                    Lastname = empDTO.Lastname,
                    ImmigrationStatus = (ImmigrationStatus)Enum.Parse(typeof(ImmigrationStatus), empDTO.ImmigrationStatus)
                };

                db.Employees.Add(employee);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employee.EmpId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Employeeapi/5
        public HttpResponseMessage DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Employees.Remove(employee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}