using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MovieStoreMvcWeb.Models.Domain;
using MovieStoreMvcWeb.Repositories.Abstract;

namespace MovieStoreMvcWeb.Controllers
{
    [Authorize]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreservice)
        {
            _genreService = genreservice;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _genreService.Add(model);
            if (result)
            {
                TempData["msg"] = "Genre Added Succesfully";
                return RedirectToAction("Add", "Genre");
            }
            else
            {
                TempData["msg"] = "Error On Server";
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            var data = _genreService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _genreService.Update(model);
            if (result)
            {
                TempData["msg"] = "Genre Updated Succesfully";
                return RedirectToAction(nameof(GenreList));
            }
            else
            {
                TempData["msg"] = "Error On Server";
                return View(model);
            }
        }

        public IActionResult GenreList()
        {
            var data = this._genreService.List().ToList();
            return View(data);
        }



        public IActionResult Delete(int id)
        {
            var result = _genreService.Delete(id);
            return RedirectToAction(nameof(GenreList));
        }


    }
}
