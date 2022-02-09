using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Data.Services;
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
            var data = await _service.GetAll();
            return View(data);
        }

        //GET: Actors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
