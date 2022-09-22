using RESTfulApi.Models;

namespace RESTfulApi.Data
{
    public interface IRepositoryBase
    {
        Task<List<SuperHero>> GetAllAsync();
        Task<SuperHero> GetAsync(int id);
        Task<SuperHero> CreateHeroAsync(SuperHero hero);
        Task<SuperHero> UpdateAsync(SuperHero hero);
        Task<SuperHero> DeleteAsync(int id);
    }
}
