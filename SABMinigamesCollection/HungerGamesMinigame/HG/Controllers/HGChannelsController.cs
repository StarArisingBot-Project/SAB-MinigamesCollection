using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGChannelsController
    {
        public DiscordChannel GameCategory { get; private set; }
        public DiscordChannel GameChannel { get; private set; }

        public void SetGameCategoryChannel(DiscordChannel category)
        {
            GameCategory = category;
        }
        public void SetGameChannel(DiscordChannel channel)
        {
            GameChannel = channel;
        }
    }
}
