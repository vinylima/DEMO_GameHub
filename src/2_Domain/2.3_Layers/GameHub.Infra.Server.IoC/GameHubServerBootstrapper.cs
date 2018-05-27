
using Microsoft.Extensions.DependencyInjection;

using GameHub.Infra.Server.Data.Context;
using GameHub.Application.Interfaces;
using GameHub.Application.AppServices;
using GameHub.Domain.Core.Interfaces.Services;
using GameHub.Domain.Core.Services;
using GameHub.Domain.Core.Interfaces.Repositories;
using GameHub.Infra.Server.Data.Repositories;

namespace GameHub.Infra.Server.IoC
{
    public static class GameHubServerBootstrapper
    {
        public static void AddGameHubDependencies(this IServiceCollection services)
        {
            services.AddDbContext<GameHub_Context>();

            // Application Services
            services.AddScoped<IGameAppService, GameAppService>();
            services.AddScoped<IFriendAppService, FriendAppService>();

            // Services
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IFriendService, FriendService>();

            // Repositories
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IFriendRepository, FriendRepository>();
        }
    }
}