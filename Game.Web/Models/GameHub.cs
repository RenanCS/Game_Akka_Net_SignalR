using Akka.Actor;
using Game.ActorModel.Messages;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Game.Web.Models
{
    public class GameHub : Hub
    {
        public void JoinGame(string playerName)
        {
            GameActorSystem.ActorReferences.SignalRBridge.Tell(new JoinGameMessage(playerName));
        }

        public void Attack(string playerName)
        {
            GameActorSystem.ActorReferences.SignalRBridge.Tell(new AttackPlayerMessage(playerName));
        }

        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
