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
    public class ConsoleTypesController : ApiController
    {
        private BlockbusterContext db = new BlockbusterContext();

        // GET: api/ConsoleTypes
        public IQueryable<ConsoleType> GetConsoles()
        {
            return db.Consoles;
        }

        // GET: api/ConsoleTypes/5
        [ResponseType(typeof(ConsoleType))]
        public async Task<IHttpActionResult> GetConsoleType(int id)
        {
            ConsoleType consoleType = await db.Consoles.FindAsync(id);
            if (consoleType == null)
            {
                return NotFound();
            }

            return Ok(consoleType);
        }

        // PUT: api/ConsoleTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConsoleType(int id, ConsoleType consoleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consoleType.ConsoleTypeId)
            {
                return BadRequest();
            }

            db.Entry(consoleType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsoleTypeExists(id))
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

        // POST: api/ConsoleTypes
        [ResponseType(typeof(ConsoleType))]
        public async Task<IHttpActionResult> PostConsoleType(ConsoleType consoleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consoles.Add(consoleType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = consoleType.ConsoleTypeId }, consoleType);
        }

        // DELETE: api/ConsoleTypes/5
        [ResponseType(typeof(ConsoleType))]
        public async Task<IHttpActionResult> DeleteConsoleType(int id)
        {
            ConsoleType consoleType = await db.Consoles.FindAsync(id);
            if (consoleType == null)
            {
                return NotFound();
            }

            db.Consoles.Remove(consoleType);
            await db.SaveChangesAsync();

            return Ok(consoleType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsoleTypeExists(int id)
        {
            return db.Consoles.Count(e => e.ConsoleTypeId == id) > 0;
        }
    }
}