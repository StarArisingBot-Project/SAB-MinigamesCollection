namespace StarArisingBot.Minigames.HungerGames
{
    public enum HGMessageType
    {
        DayAction,
        NightAction,
        MurderAction,
        TragedyAction,
        AttackAction,
    }

    public class HGMessage
    {
        public HGMessage() { }
        public HGMessage(string message, HGMessageType type, HGMessageEffect effect = null)
        {
            Content = message;
            Type = type;

            if (effect != null) Effect = effect;
        }

        public string Content { get; private set; }
        public HGMessageEffect Effect { get; private set; }
        public HGMessageType Type { get; private set; }
    }
}
