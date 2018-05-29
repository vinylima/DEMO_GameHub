
using System.Collections.Generic;
using System.Linq;

using GameHub.Domain.Core.Collections;
using GameHub.Domain.Core.Models;
using GameHub.Infra.Server.Data.Context;

namespace GameHub.Infra.Server.Data.DataLoad.Friends
{
    public static class FriendsInitialize
    {
        public static void Initializer(GameHub_Context context)
        {
            if (!context.Friends.Any())
            {
                FriendCollection friends = new FriendCollection();

                friends.Add(
                    Friend.CreateNew(
                        "Fernanda Damasceno",
                        "http://www.revistalinda.com.br/images/luciana(so-a-de-cima).jpg",
                        "damasceno.fe@gmail.com"
                    )
                );

                friends.Add(
                    Friend.CreateNew(
                        "Alexandre Tavares",
                        "https://www.etapainfantil.com/wp-content/uploads/2016/10/Comportamiento-adolescente.jpg",
                        "alessandro_ale@supermail.com"
                    )
                );

                friends.ForEach(x => context.Friends.Add(x));

                context.SaveChanges();
            }
        }
    }
}