using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.MicroRPG
{
    public class RPGControlPanel
    {
        private CommandContext Context { get; }
        private RPGMinigame RPGMinigame { get; }
        private RPGPlayer RPGPlayer { get; }

        public RPGControlPanel(CommandContext context, RPGMinigame rpgMinigame, RPGPlayer rpgPlayer)
        {
            Context = context;
            RPGMinigame = rpgMinigame;
            RPGPlayer = rpgPlayer;
        }

        public async Task SendAsync()
        {

        }
    }
}
