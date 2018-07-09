using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ASP.Net_WebAPI.Models;

namespace ASP.Net_WebAPI.Controllers
{
    public class SellingAutoAPIController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/SellingAutoAPI
        public IQueryable<SellingAuto> GetSelling_auto()
        {
            return db.Selling_auto;
        }

        // GET: api/SellingAutoAPI/5
        [ResponseType(typeof(SellingAuto))]
        public IHttpActionResult GetSellingAuto(int id)
        {
            SellingAuto sellingAuto = db.Selling_auto.Find(id);
            if (sellingAuto == null)
            {
                return NotFound();
            }

            return Ok(sellingAuto);
        }

        // PUT: api/SellingAutoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSellingAuto(int id, SellingAuto sellingAuto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sellingAuto.Id)
            {
                return BadRequest();
            }

            db.Entry(sellingAuto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellingAutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SellingAutoAPI
        [ResponseType(typeof(SellingAuto))]
        public IHttpActionResult PostSellingAuto(SellingAuto sellingAuto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Selling_auto.Add(sellingAuto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SellingAutoExists(sellingAuto.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sellingAuto.Id }, sellingAuto);
        }

        // DELETE: api/SellingAutoAPI/5
        [ResponseType(typeof(SellingAuto))]
        public IHttpActionResult DeleteSellingAuto(int id)
        {
            SellingAuto sellingAuto = db.Selling_auto.Find(id);
            if (sellingAuto == null)
            {
                return NotFound();
            }

            db.Selling_auto.Remove(sellingAuto);
            db.SaveChanges();

            return Ok(sellingAuto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SellingAutoExists(int id)
        {
            return db.Selling_auto.Count(e => e.Id == id) > 0;
        }
    }
}