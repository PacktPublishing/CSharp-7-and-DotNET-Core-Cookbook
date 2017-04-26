using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesActor.Interfaces;
using static System.Console;

namespace sfApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //var actProxy = ActorProxy.Create<IUtilitiesActor>(ActorId.CreateRandom(), "fabric:/sfApp");
            //WriteLine("Utilities Actor {0} - Valid Email?:{1}", actProxy.GetActorId()
            //    , actProxy.ValidateEmailAsync("validemail@gmail.com").Result);
            //WriteLine("Utilities Actor {0} - Valid Email?:{1}", actProxy.GetActorId()
            //    , actProxy.ValidateEmailAsync("invalid@email@gmail.com").Result);

            var actProxy = ActorProxy.Create<IUtilitiesActor>(new ActorId("Utilities"), "fabric:/sfApp");

            WriteLine("Utilities Actor {0} - Valid Email?: {1}", actProxy.GetActorId()
                , actProxy.ValidateEmailAsync("validemail@gmail.com").Result);
            WriteLine("Utilities Actor {0} - Valid Email?: {1}", actProxy.GetActorId()
                , actProxy.ValidateEmailAsync("invalid@email@gmail.com").Result);
            
            WindowHeight = 18;
            WindowWidth = 62;
            ReadLine();
        }
    }
}
