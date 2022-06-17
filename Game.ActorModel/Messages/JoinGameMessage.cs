namespace Game.ActorModel.Messages
{
    // usada quando um novo jogador entra
    public class JoinGameMessage
    {
        public JoinGameMessage(string playerName)
        {
            PlayerName = playerName;
        }

        public string PlayerName { get; private set; }

    }
}
