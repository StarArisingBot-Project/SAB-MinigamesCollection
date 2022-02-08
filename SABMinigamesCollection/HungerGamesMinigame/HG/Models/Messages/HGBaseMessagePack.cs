using System;
using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public abstract class HGBaseMessagePack
    {
        public List<HGMessage> TotalMessages => messages;
        protected List<HGMessage> messages = new List<HGMessage>();

        protected HGPlayer PlayerTarget1;
        protected HGPlayer PlayerTarget2;

        protected HGMinigame Configuration { get; private set; }

        protected Random Random = new Random();

        //Receber uma mensagem aleatoria//
        public HGMessage GetRandomMessage(HGPlayer currentPlayer, HGMinigame configuration)
        {
            Configuration = configuration;

            Reload(currentPlayer, configuration.PlayersController.GetRandomLivingPlayer(currentPlayer));

            //Selectionar e Aplicar Efeito
            HGMessage messageSelected = messages[new Random().Next(0, messages.Count - 1)];
            currentPlayer = messageSelected.Effect?.ApplyEffect(currentPlayer);

            return messageSelected;
        }

        //Recarregar e construir mensagens//
        private void Reload(HGPlayer currentPlayer, HGPlayer target2)
        {
            messages.Clear();

            PlayerTarget1 = currentPlayer;
            PlayerTarget2 = target2;

            BuildPack();
        }
        protected abstract void BuildPack();

        //Ferramentas e funções de ajuda//
        protected string GetRandomLocate()
        {
            string[] locates = {
                "no acampamento",
                "na floresta",
                "na praria"
            };

            return locates[Random.Next(0, locates.Length)];
        }
    }
}