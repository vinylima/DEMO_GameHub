
using AutoMapper;

using GameHub.Application.ViewModels;
using GameHub.Domain.Core.Models;

namespace GameHub.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FriendViewModel, Friend>();
            CreateMap<GameViewModel, Game>();
            CreateMap<LoanViewModel, Loan>();
        }
    }
}