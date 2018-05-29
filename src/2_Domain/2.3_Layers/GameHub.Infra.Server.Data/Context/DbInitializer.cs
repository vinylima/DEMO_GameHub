
using System;

using GameHub.Infra.Server.Data.DataLoad.Friends;
using GameHub.Infra.Server.Data.DataLoad.Games;

namespace GameHub.Infra.Server.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(GameHub_Context context)
        {
            context.Database.EnsureCreated();

            FriendsInitialize.Initializer(context);
            GamesInitializer.Initializer(context);
            //LoansInitializer.Initializer(context);
            
            context.Dispose();
            context = null;

            GC.Collect(0, GCCollectionMode.Forced);
        }
    }
}