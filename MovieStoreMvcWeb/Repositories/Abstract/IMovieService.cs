using MovieStoreMvcWeb.Models.Domain;
using MovieStoreMvcWeb.Models.DTO;

namespace MovieStoreMvcWeb.Repositories.Abstract
{
    public interface IMovieService
    {
        bool Add(Movie model);
        bool Update(Movie model);
        bool Delete(int id);
        Movie GetById(int id);
        IQueryable<Movie> List();
    }
}
