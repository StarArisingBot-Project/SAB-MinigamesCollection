using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.MicroRPG
{
    public class RPGMessagesController
    {
        private RPGMinigame RPGMinigame { get; set; }
        private CommandContext Context { get; set; }

        public RPGMessagesController(RPGMinigame currentMinigame, CommandContext context)
        {
            RPGMinigame = currentMinigame;
            Context = context;
        }

        public async Task SendIntroMessageAsync()
        {
            DiscordMessageBuilder message = new();
            message.AddEmbed(new DiscordEmbedBuilder() { 
                Title = ":crossed_swords: │ MICRO RPG │ :crossed_swords:",
                Description = ":star: • Seja bem-vindo ao seu canal! • :star: \n" +
                              "Aqui você verá informações e atualizações sobre o jogo, além de poder executar ações quando for sua vez. \n\n" +

                              "Para mais informações veja o tópico deste canal!",

                Color = DiscordColor.Green,
            });

            foreach (var playerChannel in RPGMinigame.ChannelsController.PlayersChannels)
            {
                await Task.Run(() => {
                    playerChannel.Channel.SendMessageAsync(message);
                }).ConfigureAwait(false);
            }
        }
        public async Task SendRoundMessageAsync()
        {
            foreach (var playerChannel in RPGMinigame.ChannelsController.PlayersChannels)
            {
                await Task.Run(() => {
                    //Other Players
                    if (RPGMinigame.RoundController.GetCurrentPlayer().ID != playerChannel.Author.Id)
                    {
                        DiscordMessageBuilder message = new();

                        message.AddEmbed(new DiscordEmbedBuilder()
                        {
                            Title = ":stopwatch: │ Aviso de Rodada │ :stopwatch:",
                            Description = $"**:game_die: │ Rodada {RPGMinigame.RoundController.CurrentRound}** \n" +
                                          $"**:boomerang: │ Vez de <@{RPGMinigame.RoundController.GetCurrentPlayer().ID}>**",
                        });
                        playerChannel.Channel.SendMessageAsync(message);
                    }
                    else //Current Player
                    {
                        new RPGControlPanel(Context, RPGMinigame, RPGMinigame.RoundController.GetCurrentPlayer()).SendAsync();
                    }
                }).ConfigureAwait(false);
            }
        }
    }
}
