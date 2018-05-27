
using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GameHub.Application.Interfaces;
using GameHub.Application.ViewModels;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHube.UI.Web.Site.Controllers
{
    public class FriendsController : Controller
    {
        private IFriendAppService _friendAppService { get; set; }

        public FriendsController(IFriendAppService friendAppService)
        {
            this._friendAppService = friendAppService;
        }

        // GET: Friends
        public async Task<ActionResult> Index()
        {
            var result = await this._friendAppService.LoadAllAsync();
            
            return View(result.ReturnResult);
        }

        // GET: Friends/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            IExecutionResult<FriendViewModel> result;

            result = await this._friendAppService.SearchByIdAsync(id);

            if (!result.Success)
            {
                // trabalhar em mensagens de erro.
            }

            return View(result.ReturnResult);
        }

        // GET: Friends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FriendViewModel friendViewModel)
        {
            IExecutionResult<bool> result = null;

            try
            {
                if (!ModelState.IsValid)
                    return View(friendViewModel);

                result = await this._friendAppService.SaveAsync(friendViewModel);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                result.SystemErrors.Add(new Message("Erro ao Cadastrar um Amigo: " + e.Message.ToString()));
            }

            return View(friendViewModel);
        }

        // GET: Friends/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await this._friendAppService.SearchByIdAsync(id);

            if(!result.Success)
            {
                // implementar aqui exibicao da mensagem de erro
            }

            return View(result.ReturnResult);
        }

        // POST: Friends/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FriendViewModel viewModel)
        {
            IExecutionResult<bool> result = null;
            try
            {
                viewModel.FriendId = id;

                if (!ModelState.IsValid)
                    return View(viewModel);

                result = await this._friendAppService.SaveAsync(viewModel);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                result.SystemErrors.Add(new Message("Erro ao Atualizar os dados do seu amigo: " + e.Message.ToString()));
            }

            return View(viewModel);
        }

        // GET: Friends/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            IExecutionResult<FriendViewModel> result;

            result = await this._friendAppService.SearchByIdAsync(id);

            if (!result.Success)
            {
                // trabalhar em mensagens de erro.
            }

            return View(result.ReturnResult);
        }

        // POST: Friends/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, FriendViewModel friendViewModel)
        {

            try
            {
                await this._friendAppService.RemoveAsync(id);
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