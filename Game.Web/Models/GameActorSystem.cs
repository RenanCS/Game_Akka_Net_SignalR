using Akka.Actor;
using Game.ActorModel.Actors;
using Game.ActorModel.ExternalSystems;
using Microsoft.AspNetCore.SignalR;
using System;

namespace Game.Web.Models
{
    public static class GameActorSystem
    {
        private static ActorSystem _ActorSystem;
        private static IGameEventsPusher _gameEventsPusher;
        private static IHubContext<GameHub> _gameHubContext;

        public static void SetGameHub(IHubContext<GameHub> gameHubContext)
        {
            _gameHubContext = gameHubContext;
        }

        public static void Create()
        {
            _gameEventsPusher = new SignalRGameEventPusher(_gameHubContext);

            _ActorSystem = ActorSystem.Create("GameSystem");

            ActorReferences.GameController = _ActorSystem.ActorOf<GameControllerActor>();

            ActorReferences.SignalRBridge = _ActorSystem.ActorOf(Props.Create(() => new SignalRBridgeActor(_gameEventsPusher, ActorReferences.GameController)), "SignalRBridge");
        }

        public static void Shutdown()
        {
            _ActorSystem.Terminate().Wait(TimeSpan.FromSeconds(1));
        }
        public static class ActorReferences
        {
            public static IActorRef GameController { get; set; }
            public static IActorRef SignalRBridge { get; set; }
        }
    }
}
