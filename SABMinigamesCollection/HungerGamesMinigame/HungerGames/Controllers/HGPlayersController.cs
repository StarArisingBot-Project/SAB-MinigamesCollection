using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGPlayersController
    {
        public List<HGPlayer> TotalPlayers { get { return totalPlayers; } }
        public List<HGPlayer> LivingPlayers { get { return livingPlayers; } }
        public List<HGPlayer> DeathPlayers { get { return deathPlayers; } }

        private List<HGPlayer> totalPlayers = new();
        private List<HGPlayer> livingPlayers = new();
        private List<HGPlayer> deathPlayers = new();

        private int currentPlayerIndex = -1;
        private readonly HGMinigame hgMinigame;

        private readonly CommandContext context;

        public HGPlayersController(HGMinigame hgMinigame, CommandContext context)
        {
            this.hgMinigame = hgMinigame;
            this.context = context;
        }

        public void SetLivingPlayers(IEnumerable<HGPlayer> players)
        {
            livingPlayers = new(players);
        }

        public HGPlayer GetCurrentActionPlayer()
        {
            if (currentPlayerIndex >= livingPlayers.Count - 1) currentPlayerIndex = 0;
            else currentPlayerIndex++;

            HGPlayer currentPlayer = livingPlayers[currentPlayerIndex];
            return currentPlayer;
        }
        public HGPlayer GetRandomLivingPlayer()
        {
            return livingPlayers[new Random().Next(0, livingPlayers.Count - 1)];
        }
        public HGPlayer GetRandomLivingPlayer(HGPlayer except)
        {
            List<HGPlayer> tempPlayers = new(livingPlayers);
            foreach (HGPlayer livingPlayer in livingPlayers)
            {
                if (livingPlayer == except)
                    tempPlayers.Remove(except);
            }

            return tempPlayers[new Random().Next(0, livingPlayers.Count - 1)];
        }

        public HGPlayer GetRandomDeathPlayer()
        {
            return deathPlayers[new Random().Next(0, deathPlayers.Count - 1)];
        }
        public void Kill(HGPlayer playerTarget)
        {
            playerTarget.CurrentHealth = 0;
            livingPlayers.Remove(playerTarget);
            deathPlayers.Add(playerTarget);
        }
    }
}
