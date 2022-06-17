namespace Game.ActorModel.Messages
{
    public class PlayerHealthChangedMessage
    {
        public PlayerHealthChangedMessage(string playerName, int health)
        {
            PlayerName = playerName;
            Health = health;
        }

        public string PlayerName { get; private set; }
        public int Health { get; private set; }
    }
}
