
using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using GameHub.Application.Interfaces;
using GameHub.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using GameHub.Shared.Kernel.Core.Interfaces;

namespace GameHube.UI.Web.Site.Controllers
{
    public class GamesController : Controller
    {
        private IGameAppService _gameAppService { get; set; }
        public GamesController(IGameAppService gameAppService)
        {
            this._gameAppService = gameAppService;
        }

        // GET: Games
        public IActionResult Index()
        {
            List<GameViewModel> games = new List<GameViewModel>
            {
                new GameViewModel
                {
                    GameId = Guid.NewGuid(),
                    Title = "Call Of Duty - Infinite Warfare",
                    ImagePath = "https://www.maistecnologia.com/wp-content/uploads/2016/09/Call-of-Duty-Infinite-Warfare.png",
                    IsFavorite = true,
                    IsBorrowed = true,
                    LoanDate = new DateTime(2018, 05, 20),
                    DevolutionPrevision = new DateTime(2018, 08, 20),
                    Status = "Restam 150 dias para o jogo ser devolvido",
                    Friend = new FriendViewModel
                    {
                        FriendId = Guid.NewGuid(),
                        Name = "Angelina Nolowvski",
                        ImagePath = "https://img.ibxk.com.br/2012/1/materias/17166216157.jpg",
                    },
                },
                /*
                new GameViewModel
                {
                    GameId = Guid.NewGuid(),
                    Title = "State Of Decay 2",
                    ImagePath = new Uri("https://gematsu.com/wp-content/uploads/2017/06/State-Decay-2-Spring-2018-Init.jpg"),
                    IsFavorite = false,
                    IsBorrowed = true,
                    LoanDate = new DateTime(2018, 05, 20),
                    PredictionReturn = new DateTime(2018, 08, 20),
                    Status = "Restam 150 dias para o jogo ser devolvido",
                    Friend = new FriendViewModel
                    {
                        FriendId = Guid.NewGuid(),
                        Name = "Sabrina Mello Batista",
                        Email = "joao@gmail.com",
                        ImagePath = new Uri("http://www.projetandopessoas.com.br/wp-content/uploads/2017/09/Flavia-Fehlberg.jpg"),
                    },
                },

                new GameViewModel
                {
                    GameId = Guid.NewGuid(),
                    Title = "End Of Game 2",
                    ImagePath = new Uri("https://gematsu.com/wp-content/uploads/2017/06/State-Decay-2-Spring-2018-Init.jpg"),
                    IsFavorite = false,
                    IsBorrowed = true,
                    Status = "Restam 150 dias para o jogo ser devolvido"
                },

                new GameViewModel
                {
                    GameId = Guid.NewGuid(),
                    Title = "End Of Game 2",
                    ImagePath = new Uri("https://gematsu.com/wp-content/uploads/2017/06/State-Decay-2-Spring-2018-Init.jpg"),
                    IsFavorite = false,
                    IsBorrowed = true,
                    Status = "Restam 150 dias para o jogo ser devolvido"
                },
                */
            };

            
            return View(games);
        }

        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GameViewModel gameViewModel)
        {
            IExecutionResult<bool> result;

            gameViewModel.GameId = new Guid("a1424fd7-1fc8-43ca-c619-08d5c379cd46");
            gameViewModel.Title = "Mortal Kombat";
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    result = this._gameAppService.Save(gameViewModel);

                    if (result.Success)
                    {
                        result.Dispose();
                        result = null;

                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {

            }
            
            return View(gameViewModel);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Games/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}