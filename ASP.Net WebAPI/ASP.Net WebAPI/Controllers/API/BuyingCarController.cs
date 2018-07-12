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

namespace ASP.Net_WebAPI.Controllers.Api
{
    public class BCController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/BC
        public IQueryable<BuyingCar> GetBuyingCarSet()
        {
            return db.BuyingCarSet;
        }

        // GET: api/BC/5
        [ResponseType(typeof(BuyingCar))]
        public IHttpActionResult GetBuyingCar(int id)
        {
            BuyingCar buyingCar = db.BuyingCarSet.Find(id);
            if (buyingCar == null)
            {
                return NotFound();
            }

            return Ok(buyingCar);
        }

        // PUT: api/BC/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBuyingCar(int id, BuyingCar buyingCar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != buyingCar.Id)
            {
                return BadRequest();
            }

            db.Entry(buyingCar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyingCarExists(id))
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

        // POST: api/BC
        [ResponseType(typeof(BuyingCar))]
        public IHttpActionResult PostBuyingCar(BuyingCar buyingCar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BuyingCarSet.Add(buyingCar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = buyingCar.Id }, buyingCar);
        }

        // DELETE: api/BC/5
        [ResponseType(typeof(BuyingCar))]
        public IHttpActionResult DeleteBuyingCar(int id)
        {
            BuyingCar buyingCar = db.BuyingCarSet.Find(id);
            if (buyingCar == null)
            {
                return NotFound();
            }

            db.BuyingCarSet.Remove(buyingCar);
            db.SaveChanges();

            return Ok(buyingCar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BuyingCarExists(int id)
        {
            return db.BuyingCarSet.Count(e => e.Id == id) > 0;
        }
    }
}