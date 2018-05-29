
using System;
using System.Threading.Tasks;
using AutoMapper;

using GameHub.Application.Interfaces;
using GameHub.Application.ViewModels;
using GameHub.Domain.Core.Interfaces.Services;
using GameHub.Domain.Core.Models;
using GameHub.Shared.Kernel.Core.Collections;
using GameHub.Shared.Kernel.Core.Interfaces;
using GameHub.Shared.Kernel.Core.Interfaces.Collections;

namespace GameHub.Application.AppServices
{
    public class FriendAppService : BaseAppService<FriendViewModel, Friend>, IFriendAppService
    {
        private IMapper mapper { get; set; }
        private IFriendService friendService { get; set; }

        public FriendAppService(IFriendService friendService, IMapper mapper) : base(friendService, mapper)
        {
            this.mapper = mapper;
            this.friendService = friendService;
        }
        
        internal override FriendViewModel ConvertModelToViewModel(Friend model)
        {
            return new FriendViewModel
            {
                FriendId = model.FriendId,
                Name = model.Name,
                ImagePath = model.ImagePath,
                Email = model.Email,
                
            };
        }

        internal override IBaseCollection<FriendViewModel> ConvertModelToViewModel(IBaseCollection<Friend> model)
        {
            IBaseCollection<FriendViewModel> collection = new BaseCollection<FriendViewModel>();

            for (int i = 0; i < model.Count; i++)
                collection.Add(this.ConvertModelToViewModel(model[i]));

            return collection;
        }

        internal override Friend ConvertViewModelToModel(FriendViewModel viewModel)
        {
            return Friend.CreateNew(
                viewModel.FriendId, 
                viewModel.Name, 
                viewModel.ImagePath, 
                viewModel.Email
            );
        }

        internal override IBaseCollection<Friend> ConvertViewModelToModel(IBaseCollection<FriendViewModel> viewModel)
        {
            IBaseCollection<Friend> collection = new BaseCollection<Friend>();

            for (int i = 0; i < viewModel.Count; i++)
                collection.Add(this.ConvertViewModelToModel(viewModel[i]));

            return collection;
        }
    }
}