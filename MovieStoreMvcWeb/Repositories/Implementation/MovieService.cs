using Microsoft.AspNetCore.Identity;
using MovieStoreMvcWeb.Models.Domain;
using MovieStoreMvcWeb.Models.DTO;
using MovieStoreMvcWeb.Repositories.Abstract;
using System.Security.Claims;

namespace MovieStoreMvcWeb.Repositories.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly DatabaseContext _dbContext;
        public MovieService(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool Add(Movie model)
        {
            if (model == null)
            {
                return false;
            }
            _dbContext.Add(model);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(Movie model)
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
            _dbContext.Movies.Remove(data);
            _dbContext.SaveChanges();
            return true;
        }

        public Movie GetById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _dbContext.Movies.Find(id);
        }

        public IQueryable<Movie> List()
        {
            var data = _dbContext.Movies.AsQueryable();
            return data;
        }
    }
}