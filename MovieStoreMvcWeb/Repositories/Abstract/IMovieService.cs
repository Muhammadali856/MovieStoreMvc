using MovieStoreMvcWeb.Models.Domain;
using MovieStoreMvcWeb.Models.DTO;

namespace MovieStoreMvcWeb.Repositories.Abstract
{
    public interface IMovieService
    {
        bool Add(Movie model);
        Movie GetById(int id);
        bool Update(Movie model);
        bool Delete(int id);
        MovieListVM List(string term = "", bool paging = false, int currentPage = 0);
        List<int> GetGenreByMovieId(int movieId);

    }
}