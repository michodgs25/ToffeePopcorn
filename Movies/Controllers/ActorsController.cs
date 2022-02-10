using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Data.Services;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //GET: Actors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")]Actor actor)
        {
            if(ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //GET ACTORS DETAILS/1

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }


        //UPDATE: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Delete: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");


            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
