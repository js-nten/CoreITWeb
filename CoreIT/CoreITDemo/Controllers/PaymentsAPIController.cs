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
    public class PaymentsAPIController : ApiController
    {
        private CoreITDemoContext db = new CoreITDemoContext();

        // GET api/PaymentsAPI
        public IEnumerable<Payment> GetPayments()
        {
            var payments = db.Payments.Include(p => p.Employee);
            return payments.AsEnumerable();
        }

        // GET api/PaymentsAPI/5
        public Payment GetPayment(int id)
        {
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return payment;
        }

        // PUT api/PaymentsAPI/5
        public HttpResponseMessage PutPayment(int id, Payment payment)
        {
            if (ModelState.IsValid && id == payment.EmpId)
            {
                db.Entry(payment).State = EntityState.Modified;

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

        // POST api/PaymentsAPI
        public HttpResponseMessage PostPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, payment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = payment.EmpId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/PaymentsAPI/5
        public HttpResponseMessage DeletePayment(int id)
        {
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Payments.Remove(payment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, payment);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}