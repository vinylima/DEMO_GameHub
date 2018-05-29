
using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using GameHub.Application.Interfaces;
using GameHub.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.ValueObjects;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameHube.UI.Web.Site.Controllers
{
    public class GamesController : Controller
    {
        private IGameAppService _gameAppService { get; set; }
        private IFriendAppService _friendAppService { get; set; }

        public GamesController(IGameAppService gameAppService, IFriendAppService friendAppService)
        {
            this._gameAppService = gameAppService;
            this._friendAppService = friendAppService;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var result = await this._gameAppService.LoadAllAsync();

            return View(result.ReturnResult);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            IExecutionResult<GameViewModel> result;

            result = await this._gameAppService.SearchByIdAsync(id, true);

            if (!result.Success)
            {
                // trabalhar em mensagens de erro.
            }

            return View(result.ReturnResult);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameViewModel gameViewModel)
        {
            IExecutionResult<bool> result = null;
            
            try
            {
                /*
                if (!ModelState.IsValid)
                    return View(gameViewModel);
                    */
                result = await this._gameAppService.SaveAsync(gameViewModel);

                if (result.Success)
                {
                    gameViewModel.Dispose();
                    gameViewModel = null;

                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception e)
            {
                result.SystemErrors.Add(new Message("Erro ao Cadastrar um Jogo: " + e.Message.ToString()));
            }
            
            return View(gameViewModel);
        }

        // GET: Games/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await this._gameAppService.SearchByIdAsync(id);

            ViewBag.Friends = this._friendAppService.LoadAll().ReturnResult;
            
            if (!result.Success)
            {
                // implementar aqui exibicao da mensagem de erro
            }
            
            return View(result.ReturnResult);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GameViewModel gameViewModel)
        {
            IExecutionResult<bool> result = null;
            try
            {
                gameViewModel.GameId = id;
                
                result = await this._gameAppService.SaveAsync(gameViewModel);

                if (result.Success)
                {
                    gameViewModel.Dispose();
                    gameViewModel = null;

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                result.SystemErrors.Add(new Message("Erro ao Atualizar os dados do seu Jogo: " + e.Message.ToString()));
            }

            return View(gameViewModel);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            IExecutionResult<GameViewModel> result;

            result = await this._gameAppService.SearchByIdAsync(id);

            if (!result.Success)
            {
                // trabalhar em mensagens de erro.
            }

            return View(result.ReturnResult);
        }

        // POST: Games/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, GameViewModel gameViewModel)
        {
            IExecutionResult<bool> result = null;

            try
            {
                result = await this._gameAppService.RemoveAsync(id);

                if (result.Success)
                {
                    gameViewModel.Dispose();
                    gameViewModel = null;

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                result.SystemErrors.Add(new Message("Erro ao Excluir seu Jogo: " + e.Message.ToString()));
            }

            return View(gameViewModel);
        }
    }
}