using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using MovieREST.Models;

namespace MovieREST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MovieInfoesController : ApiController
    {

        private MovieDBEntities db = new MovieDBEntities();

        // GET: api/MovieInfoes
        public IQueryable<MovieInfo> GetMovieInfo()
        {
            return db.MovieInfo.Distinct();
        }

        // GET: api/MovieInfoes/5
        [ResponseType(typeof(MovieInfo))]
        public IHttpActionResult GetMovieInfo(int id)
        {
            MovieInfo movieInfo = db.MovieInfo.Find(id);
            if (movieInfo == null)
            {
                return NotFound();
            }

            return Ok(movieInfo);
        }
        [ResponseType(typeof(MovieInfo))]
        public IHttpActionResult GetMovieInfo(string title)
        {
            var a = from t in db.MovieInfo
                    where t.Title == title
                    select t;

            return Ok(a.ToList());
        }

        // PUT: api/MovieInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovieInfo(int id, MovieInfo movieInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(movieInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieInfoExists(id))
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

        // POST: api/MovieInfoes
        [ResponseType(typeof(MovieInfo))]
        public IHttpActionResult PostMovieInfo(MovieInfo movieInfo)
        {

            //MovieInfo movieInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MovieInfo>(JSONmovieInfo);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MovieInfo.Add(movieInfo);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = movieInfo.ID }, movieInfo);
            return Ok(movieInfo);
        }

        // DELETE: api/MovieInfoes/5
        [ResponseType(typeof(MovieInfo))]
        public IHttpActionResult DeleteMovieInfo(int id)
        {
            MovieInfo movieInfo = db.MovieInfo.Find(id);
            if (movieInfo == null)
            {
                return NotFound();
            }

            db.MovieInfo.Remove(movieInfo);
            db.SaveChanges();

            return Ok(movieInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieInfoExists(int id)
        {
            return db.MovieInfo.Count(e => e.ID == id) > 0;
        }
    }
}