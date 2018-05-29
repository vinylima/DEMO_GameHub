
using System;
using System.Threading.Tasks;
using AutoMapper;
using GameHub.Application.Interfaces;
using GameHub.Application.ViewModels;
using GameHub.Domain.Core.Interfaces.Services;
using GameHub.Domain.Core.Models;
using GameHub.Domain.Core.Scopes.Games;
using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Application.AppServices
{
    public class GameAppService : BaseAppService<GameViewModel, Game>, IGameAppService
    {
        private IGameService _gameService { get; set; }

        public GameAppService(IGameService gameService, IMapper mapper) : base(gameService, mapper)
        {
            this._gameService = gameService;
        }

        public async Task<IExecutionResult<GameViewModel>> SearchByIdAsync(Guid id, bool loadLoans)
        {
            IExecutionResult<GameViewModel> execResult = new ExecutionResult<GameViewModel>();
            
            var result = await this._gameService.SearchByIdAsync(id, loadLoans);

            execResult.Merge(result);

            execResult.DefineResult(
                this.Mapper.Map<GameViewModel>(result.ReturnResult)
            );

            result.Dispose();
            result = null;

            return execResult;
        }

        public override async Task<IExecutionResult<bool>> SaveAsync(GameViewModel gameViewModel)
        {
            IExecutionResult<bool> execResult = new ExecutionResult<bool>();
            bool isBorrowed = false;

            var game = this._gameService.SearchByIdAsync(gameViewModel.GameId, true);


            
            isBorrowed = this._gameService.IsBorrowed(gameViewModel.GameId).ReturnResult;

            //var game = this.ConvertViewModelToModel(gameViewModel);
            
            // Jogo nao está e nao foi emprestado
            // TODO: encapsular lógica de decisao
            if(!isBorrowed && gameViewModel.CurrentLoan == null)
            {
                execResult = await base.SaveAsync(gameViewModel);

                return execResult;
            }

            // O Jogo nao estava emprestado mas acabou de ser
            if(!isBorrowed && gameViewModel.CurrentLoan != null)
            {
                //this._gameService.
            }

            // O Jogo estava emprestado a um amigo e foi emprestado, logo em seguida, a outro
            if(isBorrowed && gameViewModel.CurrentLoan != null)
            {
                //this._gameService.GiveBack(game);
            }

            // Jogo foi emprestado a alguém
            if(gameViewModel.CurrentLoan != null)
            {
                //game.DefineBorrowedStatus(true);

                

                /*
                execResult.Merge(
                    this._gameService.LendGame(
                        game.GenerateLoan(game.Friend, gameViewModel.CurrentLoan.LoanDate, gameViewModel.CurrentLoan.DevolutionPrevision)
                    )
                );
                */
            }
            else
            {
                /*
                execResult.Merge(
                    this._gameService.GiveBack(game)
                );
                */
            }

            return execResult;
        }
        

        internal override GameViewModel ConvertModelToViewModel(Game model)
        {
            var gameViewModel = new GameViewModel
            {
                GameId = model.GameId,
                Title = model.Title,
                ImagePath = model.ImagePath.ToString(),
                IsFavorite = model.IsFavorite,
                IsBorrowed = model.IsBorrowed,
                LastLoan = model.LastLoan,
            };

            if(model.CurrentLoan != null)
            {
                gameViewModel.CurrentLoan = new LoanViewModel
                {
                    LoanId = model.CurrentLoan.LoanId,
                    LoanDate = model.CurrentLoan.LoanDate,
                    DevolutionPrevision = model.CurrentLoan.DevolutionPrevision,
                    EfetiveDevolution = model.CurrentLoan.EfectiveDevolution,
                    Friend = new FriendViewModel
                    {
                        FriendId = model.CurrentLoan.FriendId,
                        Name = model.CurrentLoan.Friend.Name,
                        Email = model.CurrentLoan.Friend.Email,
                        ImagePath = model.CurrentLoan.Friend.ImagePath,
                        ReputationLevel = model.CurrentLoan.Friend.ReputationLevel,
                    },
                    Game = new GameViewModel
                    {
                        GameId = model.GameId,
                        Title = model.CurrentLoan.Game.Title,
                        ImagePath = model.CurrentLoan.Game.ImagePath,
                        IsBorrowed = model.CurrentLoan.Game.IsBorrowed,
                        IsFavorite = model.CurrentLoan.Game.IsFavorite,
                        LastLoan = model.CurrentLoan.Game.LastLoan,
                    }
                };
            }

            return gameViewModel;
        }

        internal override IBaseCollection<GameViewModel> ConvertModelToViewModel(IBaseCollection<Game> model)
        {
            IBaseCollection<GameViewModel> collection = new BaseCollection<GameViewModel>();

            for (int i = 0; i < model.Count; i++)
                collection.Add(this.ConvertModelToViewModel(model[i]));

            return collection;
        }

        internal override Game ConvertViewModelToModel(GameViewModel viewModel)
        {
            var game = Game.CreateNew(
                viewModel.GameId, 
                viewModel.Title, 
                new Uri(viewModel.ImagePath), 
                viewModel.IsFavorite, 
                viewModel.IsBorrowed,
                viewModel.LastLoan
            );

            if(viewModel.CurrentLoan != null)
            {
                game.LendTo(
                    Friend.CreateNew(
                        viewModel.CurrentLoan.Friend.FriendId,
                        viewModel.CurrentLoan.Friend.Name,
                        viewModel.CurrentLoan.Friend.ImagePath,
                        viewModel.CurrentLoan.Friend.Email
                    )
                );
            }

            return game;
        }
        
        internal override IBaseCollection<Game> ConvertViewModelToModel(IBaseCollection<GameViewModel> viewModel)
        {
            IBaseCollection<Game> collection = new BaseCollection<Game>();

            for (int i = 0; i < viewModel.Count; i++)
                collection.Add(this.ConvertViewModelToModel(viewModel[i]));

            return collection;
        }
        
    }
}
