using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGMessagesController
    {
        private readonly HGMinigame hgMinigame;
        private readonly CommandContext context;

        public HGMessagesController(HGMinigame configuration, CommandContext context)
        {
            hgMinigame = configuration;
            context = context;
        }

        public async Task Start()
        {
            await hgMinigame.ChannelsController.GameChannel.SendMessageAsync(GameStartMessage());
            Thread.Sleep(1000);
            await hgMinigame.ChannelsController.GameChannel.SendMessageAsync("\n**OS JOGOS COMEÇARÃO EM 10 SEGUNDOS** \n");
            Thread.Sleep(9000);

            try
            {
                await HistoryStart();
            }
            catch (Exception e)
            {
                await hgMinigame.ChannelsController.GameChannel.SendMessageAsync(e.ToString());
            }
        }
        private async Task HistoryStart()
        {
            try
            {
                //Ainda há jogadores vivos
                while (hgMinigame.PlayersController.LivingPlayers.Count > 1)
                {
                    Thread.Sleep(2000);

                    //Enviar mensagem do estado atual do dia
                    if (hgMinigame.WorldController.IsDay)
                    {
                        await hgMinigame.ChannelsController.GameChannel.SendMessageAsync(NewDayMessage());
                        Thread.Sleep(2000);

                        //Jogadores vivos
                        await hgMinigame.ChannelsController.GameChannel.SendMessageAsync(LivingPlayersListMessage());
                    }
                    else
                    {
                        await hgMinigame.ChannelsController.GameChannel.SendMessageAsync(NewNightMessage());
                    }

                    Thread.Sleep(5000);

                    //Ainda há dialogos faltando
                    while (hgMinigame.WorldController.RemainingDialogues > 0)
                    {
                        if (hgMinigame.PlayersController.LivingPlayers.Count == 1)
                            break;

                        await hgMinigame.ChannelsController.GameChannel.SendMessageAsync(PlayerActionMessage());
                        hgMinigame.WorldController.RemainingDialogues--;

                        Thread.Sleep(5000);
                    }

                    hgMinigame.WorldController.SwapDayState();

                    if (hgMinigame.WorldController.IsDay) hgMinigame.WorldController.CurrentDay++;
                }
            }
            catch (Exception e)
            {
                await hgMinigame.ChannelsController.GameChannel.SendMessageAsync(e.ToString());
            }

            await hgMinigame.ChannelsController.GameChannel.SendMessageAsync(PlayerWinsMessage());
            await hgMinigame.EndMinigame();
        }

        //==============================//
        private DiscordMessageBuilder GameStartMessage()
        {
            DiscordMessageBuilder result = new DiscordMessageBuilder();
            DiscordEmbedBuilder startGameEmbed = new DiscordEmbedBuilder();

            startGameEmbed.WithTitle(":crossed_swords: ◆ O HUNGER GAMES ESTÁ COMEÇANDO ◆ :crossed_swords:");
            startGameEmbed.WithDescription("》 Se passaram longos 5 anos esperando por este momentos e finalmente chegou, Sejam todos muitíssimos bem-vindos à mais uma **Edição dos Jogos Vorazes**! \n\n" +
                                           $"》 Após o intenso treinamento e apresentação de todos os **{hgMinigame.PlayersController.TotalPlayers.Count}** tributos ao mundo chegou a hora de todos demonstrarem suas habilidades no famoso jogo de vida ou morte onde no final, apenas um sairá vivo e levará o glorioso premio, Boa Sorte e bons **Jogos Vorazes** a todos!");
            startGameEmbed.WithColor(DiscordColor.Gold);

            result.WithEmbed(startGameEmbed);
            return result;
        }
        private DiscordMessageBuilder NewDayMessage()
        {
            DiscordMessageBuilder result = new DiscordMessageBuilder();
            DiscordEmbedBuilder newDayEmbed = new DiscordEmbedBuilder();

            newDayEmbed.WithTitle(":sun_with_face: ● UM NOVO DIA RECAI SOBRE A ILHA ● :sun_with_face:");
            newDayEmbed.WithDescription($@"》""Bom Dia a todos os tributos ainda vivos! Hoje é o **{hgMinigame.WorldController.CurrentDay}° Dia** que vocês estão na Ilha. Para Alegria ou Infelicidade de vocês, ainda restam **{hgMinigame.PlayersController.LivingPlayers.Count}** Tributos vivos, Se Cuidem!""" +
                                          "\n\n ➥ **Após o aviso todos se preparam para mais um dia.**");
            newDayEmbed.WithColor(DiscordColor.Green);

            result.AddEmbed(newDayEmbed);
            return result;
        }
        private DiscordMessageBuilder NewNightMessage()
        {
            DiscordMessageBuilder result = new();
            DiscordEmbedBuilder newNightEmbed = new();

            newNightEmbed.WithTitle(":last_quarter_moon_with_face: ● A NOITE RECAI SOBRE À ILHA ● :last_quarter_moon_with_face:");
            newNightEmbed.WithDescription("O Ambiente está escuro e o medo prevalece no silêncio mortal.");
            newNightEmbed.WithColor(DiscordColor.MidnightBlue);

            result.AddEmbed(newNightEmbed);
            return result;
        }
        private DiscordMessageBuilder LivingPlayersListMessage()
        {
            hgMinigame.PlayersController.LivingPlayers.Sort(new Comparison<HGPlayer>((i1, i2) => i2.TotalKills.CompareTo(i1.TotalKills)));

            DiscordMessageBuilder result = new DiscordMessageBuilder();
            DiscordEmbedBuilder playersLivingList = new DiscordEmbedBuilder();

            string livingPlayersList = "";
            int currentPlayerCount = 0;
            foreach (HGPlayer player in hgMinigame.PlayersController.LivingPlayers)
            {
                livingPlayersList += $"**{currentPlayerCount})** ● **{player.Name}** ({player.TotalKills} Kills) \n";
                currentPlayerCount++;
            }

            if (livingPlayersList.Length > 2000)
                livingPlayersList = "[Esta lista passou de 2000 caracteres, em breve será mostrado os jogdaores]";

            //Escrever lista de jogadores vivos
            playersLivingList.WithTitle("👥 ● TRIBUTOS VIVOS ● 👥");
            playersLivingList.WithDescription($"● Restam **{hgMinigame.PlayersController.LivingPlayers.Count}** Tributos Vivos. \n" +
                                              $"● Já morreram **{hgMinigame.PlayersController.DeathPlayers.Count}** Tributos. \n\n" +
                                              $"**Lista dos Tributos Vivos:** \n{livingPlayersList}");
            playersLivingList.WithColor(DiscordColor.Purple);

            result.WithEmbed(playersLivingList);
            return result;
        }

        private DiscordMessageBuilder PlayerActionMessage()
        {
            HGPlayer playerSelected = hgMinigame.PlayersController.GetCurrentActionPlayer();
            HGMessage playerAction = playerSelected.GetRandomAction(hgMinigame);

            DiscordMessageBuilder result = new DiscordMessageBuilder();
            DiscordEmbedBuilder embedAction = new DiscordEmbedBuilder();

            embedAction.WithDescription(playerAction.Content);
            switch (playerAction.Type)
            {
                case HGMessageType.DayAction:
                    embedAction.WithColor(DiscordColor.Cyan);
                    break;

                case HGMessageType.MurderAction:
                    embedAction.WithColor(DiscordColor.Red);
                    break;

                case HGMessageType.TragedyAction:
                    embedAction.WithColor(DiscordColor.DarkRed);
                    break;

                case HGMessageType.AttackAction:
                    embedAction.WithColor(DiscordColor.Orange);
                    break;

                case HGMessageType.NightAction:
                    embedAction.WithColor(DiscordColor.DarkBlue);
                    break;
            }

            result.AddEmbed(embedAction);
            return result;
        }
        private DiscordMessageBuilder PlayerWinsMessage()
        {
            DiscordMessageBuilder result = new DiscordMessageBuilder();
            DiscordEmbedBuilder winEmbed = new DiscordEmbedBuilder();

            winEmbed.WithTitle("🏆 ● FIM DOS JOGOS VORAZES ● 🏆");
            winEmbed.WithDescription("Depois de uma intensa batalha entre todos os Destritos junto de seus Tributos... **TEMOS UM VENCENDOR!!!** \n\n" +
                                     $"⫷ E o vencedor destá Edição é... **{hgMinigame.PlayersController.LivingPlayers[0].Name.ToUpper()}** que sai da arena com toda sua maestria ⫸ \n" +
                                     $"『 **Aproveite o seu grandissimo premio e Seja Bem-Vindo ao Caminho da Vitoria, em 25 anos nós nos veremos novamente.** 』");
            winEmbed.WithColor(DiscordColor.Yellow);

            result.AddEmbed(winEmbed);
            return result;
        }
    }
}
