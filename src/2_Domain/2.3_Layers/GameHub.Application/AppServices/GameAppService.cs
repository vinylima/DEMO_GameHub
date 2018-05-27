
using System;

using AutoMapper;

using GameHub.Application.Interfaces;
using GameHub.Application.ViewModels;
using GameHub.Domain.Core.Interfaces.Services;
using GameHub.Domain.Core.Models;
using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;

namespace GameHub.Application.AppServices
{
    public class GameAppService : BaseAppService<GameViewModel, Game>, IGameAppService
    {
        public GameAppService(IGameService baseService /*, IMapper mapper*/) : base(baseService /*, mapper*/)
        {

        }

        internal override GameViewModel ConvertModelToViewModel(Game model)
        {
            return new GameViewModel
            {
                GameId = model.GameId,
                Title = model.Title,
                ImagePath = model.ImagePath.ToString(),
                IsFavorite = model.IsFavorite,
                IsBorrowed = model.IsBorrowed,
                LastLoan = model.LastLoan,
            };
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
            return Game.CreateNew(
                viewModel.GameId, 
                viewModel.Title, 
                new Uri(viewModel.ImagePath), 
                viewModel.IsFavorite, 
                viewModel.IsBorrowed,
                viewModel.LastLoan,
                Friend.CreateNew(
                    viewModel.Friend.FriendId, 
                    viewModel.Friend.Name, 
                    viewModel.Friend.ImagePath, 
                    viewModel.Friend.Email
                )
            );
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
