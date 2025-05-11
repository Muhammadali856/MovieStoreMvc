using Microsoft.AspNetCore.Identity;
using MovieStoreMvcWeb.Models.Domain;
using MovieStoreMvcWeb.Models.DTO;
using MovieStoreMvcWeb.Repositories.Abstract;
using System.Security.Claims;

namespace MovieStoreMvcWeb.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext _dbContext;
        public GenreService(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool Add(Genre model)
        {
            if (model == null)
            {
                return false;
            }
            _dbContext.Add(model);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(Genre model)
        {
            if (model == null)
            {
                return false;
            }
            _dbContext.Update(model);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var data = this.GetById(id);
            if (data == null)
            {
                return false;
            }
            _dbContext.Genres.Remove(data);
            _dbContext.SaveChanges();
            return true;
        }

        public Genre GetById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _dbContext.Genres.Find(id);
        }

        public IQueryable<Genre> List()
        {
            var data = _dbContext.Genres.AsQueryable();
            return data;
        }
    }
}