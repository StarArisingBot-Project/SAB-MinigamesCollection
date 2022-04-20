using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.MicroRPG
{
    public class RPGRoundController
    {
        public int CurrentRound { get; private set; }
        public int CurrentPlayerNumber { get; private set; }

        //===========================//

        private RPGMinigame RPGMinigame { get; set; }
        private CommandContext Context { get; set; }

        public RPGRoundController(RPGMinigame currentMinigame, CommandContext context)
        {
            RPGMinigame = currentMinigame;
            Context = context;
        }

        //===========================//

        public RPGPlayer GetCurrentPlayer()
        {
            return RPGMinigame.PlayersController.LivingPlayers[CurrentPlayerNumber];
        }
    }
}
