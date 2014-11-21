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
using CoreITDemo.Models;

namespace CoreITDemo.Controllers
{
    public class SalaryAPIController : ApiController
    {
        private CoreITDemoContext db = new CoreITDemoContext();

        // GET api/SalaryAPI
        public IEnumerable<Salary> GetSalaries()
        {
            var salaries = db.Salaries.Include(s => s.Employee);
            return salaries.AsEnumerable();
        }

        // GET api/SalaryAPI/5
        public Salary GetSalary(int id)
        {
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return salary;
        }

        // PUT api/SalaryAPI/5
        public HttpResponseMessage PutSalary(int id, Salary salary)
        {
            if (ModelState.IsValid && id == salary.EmpId)
            {
                db.Entry(salary).State = EntityState.Modified;

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

        // POST api/SalaryAPI
        public HttpResponseMessage PostSalary(Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Salaries.Add(salary);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, salary);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = salary.EmpId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/SalaryAPI/5
        public HttpResponseMessage DeleteSalary(int id)
        {
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Salaries.Remove(salary);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, salary);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}