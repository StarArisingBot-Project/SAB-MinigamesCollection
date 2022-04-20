using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.MicroRPG
{
    public class RPGCommandsController
    {
        private RPGMinigame RPGMinigame { get; set; }
        private CommandContext Context { get; set; }

        public RPGCommandsController(RPGMinigame currentMinigame, CommandContext context)
        {
            RPGMinigame = currentMinigame;
            Context = context;
        }
    }
}
