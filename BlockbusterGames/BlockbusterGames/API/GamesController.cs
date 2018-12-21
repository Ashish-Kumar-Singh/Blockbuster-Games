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
    public class GamesController : ApiController
    {
        private BlockbusterContext db = new BlockbusterContext();

        // GET: api/Games
        public IQueryable<GameDTO> GetGames()
        {
            var games = from g in db.Games
                        select new GameDTO()
                        {
                            GameId = g.GameId,
                            Name = g.Name,
                            price = g.price,
                            GenreId = g.GenreId,
                            ConsoleTypeId = g.ConsoleTypeId,
                            Release_Date = g.Release_Date
                        };
            return games;
        }

        // GET: api/Games/5
        [ResponseType(typeof(GameDTO))]
        public async Task<IHttpActionResult> GetGame(int id)
        {
            Game g = await db.Games.FindAsync(id);
            if (g == null)
            {
                return NotFound();
            }

            GameDTO game = new GameDTO
            {
                GameId = g.GameId,
                Name = g.Name,
                price = g.price,
                GenreId = g.GenreId,
                ConsoleTypeId = g.ConsoleTypeId,
                Release_Date = g.Release_Date
            };
            return Ok(game);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGame(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.GameId)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = game.GameId }, game);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> DeleteGame(int id)
        {
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            await db.SaveChangesAsync();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.GameId == id) > 0;
        }
    }
}