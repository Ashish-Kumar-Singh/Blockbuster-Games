using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BlockbusterGames.Models;

namespace BlockbusterGames.API
{
    public class RentsController : ApiController
    {
        private BlockbusterContext db = new BlockbusterContext();

        // GET: api/Rents
        public IQueryable<RentDTO> GetRents()
        {
            var rents = from r in db.Rents
                        select new RentDTO()
                        {
                            RentId= r.RentId,
                            CustomerId=r.CustomerId,
                            GameId=r.GameId,
                            No_Of_Days=r.No_Of_Days
                        };
            return rents;
        }

        // GET: api/Rents/5
        [ResponseType(typeof(RentDTO))]
        public async Task<IHttpActionResult> GetRent(int id)
        {
            Rent r = await db.Rents.FindAsync(id);
            if( r == null)
            {
                return NotFound();
            }

            RentDTO rent = new RentDTO
            {
                RentId = r.RentId,
                CustomerId = r.CustomerId,
                GameId = r.GameId,
                No_Of_Days = r.No_Of_Days

            };

            return Ok(rent);
        }

        // PUT: api/Rents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRent(int id, Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rent.RentId)
            {
                return BadRequest();
            }

            db.Entry(rent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
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

        // POST: api/Rents
        [ResponseType(typeof(Rent))]
        public async Task<IHttpActionResult> PostRent(Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rents.Add(rent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rent.RentId }, rent);
        }

        // DELETE: api/Rents/5
        [ResponseType(typeof(Rent))]
        public async Task<IHttpActionResult> DeleteRent(int id)
        {
            Rent rent = await db.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            db.Rents.Remove(rent);
            await db.SaveChangesAsync();

            return Ok(rent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentExists(int id)
        {
            return db.Rents.Count(e => e.RentId == id) > 0;
        }
    }
}