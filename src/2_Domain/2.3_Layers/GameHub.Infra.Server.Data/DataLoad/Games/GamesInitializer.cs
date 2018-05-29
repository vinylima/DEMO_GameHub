
using System;
using System.Linq;

using GameHub.Domain.Core.Collections;
using GameHub.Domain.Core.Models;
using GameHub.Infra.Server.Data.Context;

namespace GameHub.Infra.Server.Data.DataLoad.Games
{
    public static class GamesInitializer
    {
        public static void Initializer(GameHub_Context context)
        {
            if (!context.Games.Any())
            {
                GameCollection games = new GameCollection();

                games.Add(
                    Game.CreateNew(
                        "Call Of Duty - Black OPS III",
                        new Uri("http://www.komputerswiat.pl/gamezilla/media/2015/313/3733929/blackops3_Open.jpg"),
                        true
                    )
                );

                games.Add(
                    Game.CreateNew(
                        "Counter Strike GO",
                        new Uri("https://www.hrejihned.cz/gallery/products/middle/2175.jpg"),
                        true,
                        true,
                        new DateTime(2018, 05, 28)
                    )
                );

                games[games.Count - 1].LendTo(
                    context.Friends.Where(f => f.Name.ToLower().Equals("Fernanda Damasceno".ToLower())).FirstOrDefault()
                );

                //

                games.ForEach(g => context.Games.Add(g));

                context.SaveChanges();
            }
        }
    }
}