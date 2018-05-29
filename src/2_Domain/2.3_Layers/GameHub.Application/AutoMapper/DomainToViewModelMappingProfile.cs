
using AutoMapper;

using GameHub.Application.ViewModels;
using GameHub.Domain.Core.Models;

namespace GameHub.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Friend, FriendViewModel>();
            CreateMap<Game, GameViewModel>();
            CreateMap<Loan, LoanViewModel>();
        }
    }
}