using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using MovieREST.Models;

namespace MovieREST.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Leffahaku(int? id = null, string title = "")
        {
            string path = "";
            if (id == null)
            {
                path = $"http://localhost:31159//api/movieinfoes/title/{title}";
            }
            else if (title == "")
            {
                path = $"http://localhost:31159//api/movieinfoes/{id}";
            }

            string json = "";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(path).Result;
                json = response.Content.ReadAsStringAsync().Result;
            }

            if (title == "")
            {
                MovieInfo movie;
                movie = JsonConvert.DeserializeObject<MovieInfo>(json);
                return View("moviesearch", movie);
            }
            else
            {
                List<MovieInfo> movies;
                movies = JsonConvert.DeserializeObject<List<MovieInfo>>(json);
                return View("movielist", movies);

            }

        }
    }
}
