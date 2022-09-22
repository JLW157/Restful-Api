using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuperHeroWeb.Models;
using System.Text;

namespace SuperHeroWeb.Controllers
{
    public class HeroController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7081");
        HttpClient client;
        public HeroController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SuperHero>? superHeros = new List<SuperHero>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "api/SuperHero/heros").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                superHeros = JsonConvert.DeserializeObject<List<SuperHero>>(data);
                return View(superHeros);
            }
            else
            {
                return NotFound("Heros not found or DB is empty");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SuperHero hero)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(hero);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "api/SuperHero/add", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            SuperHero? superHero = new SuperHero();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "api/SuperHero/heros/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                superHero = JsonConvert.DeserializeObject<SuperHero>(data);
                return View(superHero);
            }
            else
            {
                return NotFound("Hero not found");
            }
        }

        [HttpPost]
        public IActionResult Edit(SuperHero hero)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(hero);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "api/SuperHero/update", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "api/SuperHero/delete/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}
