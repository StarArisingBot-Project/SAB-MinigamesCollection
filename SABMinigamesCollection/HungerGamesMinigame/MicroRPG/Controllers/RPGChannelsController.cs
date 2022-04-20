using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.MicroRPG
{
    public class RPGChannelsController
    {
        public DiscordChannel CategoryChannel { get; private set; }
        public IEnumerable<RPGChannel> PlayersChannels { get; private set; }

        //==========================================//

        private RPGMinigame RPGMinigame { get; set; }
        private CommandContext Context { get; set; }

        public RPGChannelsController(RPGMinigame currentMinigame, CommandContext context)
        {
            RPGMinigame = currentMinigame;
            Context = context;
        }

        //==========================================//

        public async Task SetCategoryChannelAsync(DiscordChannel category)
        {
            CategoryChannel = category;
            await Task.CompletedTask;
        }
        public async Task SetPlayersChannelAsync(IEnumerable<RPGChannel> channels)
        {
            PlayersChannels = channels;
            await Task.CompletedTask;
        }
    }
}
