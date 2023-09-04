using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Api_Football.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
                client.DefaultRequestHeaders.Add("x-rapidapi-key", "272979679a58c62d8c17ae97529bd419");

                var queryParams = new System.Collections.Specialized.NameValueCollection
                {
                    { "season", "2019" },
                    { "team", "33" },
                    { "league", "39" }
                };

                var url = "https://v3.football.api-sports.io/teams/statistics?" + string.Join("&", queryParams.AllKeys.Select(key => $"{key}={queryParams[key]}"));

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ViewBag.APIResponse = content;
                }
                else
                {
                    ViewBag.APIResponse = "Error al obtener los datos de la API.";
                }
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Destacado()
        {
            ViewBag.Message = "The best player";

            return View();
        }
        public ActionResult Predicciones()
        {
            ViewBag.Message = "Predicciones";

            return View();
        }
    }
}