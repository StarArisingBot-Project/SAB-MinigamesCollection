using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.MicroRPG
{
    public class RPGPlayersController
    {
        public List<RPGPlayer> TotalPlayers { get; private set; }
        public List<RPGPlayer> LivingPlayers { get; private set; }
        public List<RPGPlayer> DeathPlayers { get; private set; }

        //============================//

        private RPGMinigame RPGMinigame { get; set; }
        private CommandContext Context { get; set; }

        public RPGPlayersController(RPGMinigame currentMinigame, CommandContext context)
        {
            RPGMinigame = currentMinigame;
            Context = context;
        }

        //============================//
        public async Task BuildPlayersAsync(IEnumerable<RPGPlayer> players)
        {
            TotalPlayers = new(players);
            LivingPlayers = new(TotalPlayers);
            DeathPlayers = new();
        }
    }
}
