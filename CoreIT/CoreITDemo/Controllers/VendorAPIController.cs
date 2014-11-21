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
    public class VendorAPIController : ApiController
    {
        private CoreITDemoContext db = new CoreITDemoContext();

        // GET api/Vendor
        public IEnumerable<Vendor> GetVendors()
        {
            return db.Vendors.AsEnumerable();
        }

        // GET api/Vendor/5
        public Vendor GetVendor(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return vendor;
        }

        // PUT api/Vendor/5
        public HttpResponseMessage PutVendor(int id, Vendor vendor)
        {
            if (ModelState.IsValid && id == vendor.VendorId)
            {
                db.Entry(vendor).State = EntityState.Modified;

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

        // POST api/Vendor
        public HttpResponseMessage PostVendor(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, vendor);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = vendor.VendorId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Vendor/5
        public HttpResponseMessage DeleteVendor(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Vendors.Remove(vendor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, vendor);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}