using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTfulApi.Data;
using RESTfulApi.Models;

namespace RESTfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IRepositoryBase heros;

        public SuperHeroController(IRepositoryBase heros)
        {
            this.heros = heros;
        }

        [HttpGet]
        [Route("heros")]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await heros.GetAllAsync());
        }

        // GET heros/1
        [HttpGet]
        [Route("heros/{id:int}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            return Ok(await heros.GetAsync(id));
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
        {
            return Ok(await heros.CreateHeroAsync(hero));
        }


        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero hero)
        {
            return Ok(await heros.UpdateAsync(hero));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {

            return Ok(await heros.DeleteAsync(id));
        }


    }
}
