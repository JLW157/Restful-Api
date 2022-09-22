using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using RESTfulApi.Models;
using System.Text.RegularExpressions;

namespace RESTfulApi.Data
{
    public class HeroRepository : IRepositoryBase
    {
        private readonly HerosDbContext context;

        // DI
        public HeroRepository(HerosDbContext context)
        {
            this.context = context;
        }

        public async Task<SuperHero> CreateHeroAsync(SuperHero hero)
        {
            await context.SuperHeroes.AddAsync(hero);
            await context.SaveChangesAsync();
            return hero;
        }

        public async Task<SuperHero> DeleteAsync(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            context.SuperHeroes.Remove(hero);
            await context.SaveChangesAsync();
            return hero;
        }

        public async Task<List<SuperHero>> GetAllAsync()
        {
            var heros = await context.SuperHeroes.ToListAsync();
            return heros;
        }

        public async Task<SuperHero> GetAsync(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            return hero;
        }

        public async Task<SuperHero> UpdateAsync(SuperHero hero)
        {
            var heroToChange = await context.SuperHeroes.FindAsync(hero.Id);
            heroToChange.Age = hero.Age;
            heroToChange.Name = hero.Name;

            await context.SaveChangesAsync();

            return heroToChange;
        }
    }
}
