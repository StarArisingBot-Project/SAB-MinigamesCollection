using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGCommandsController
    {
        private readonly HGMinigame hgMinigame;
        private readonly CommandContext context;

        private delegate Task CommandExecuted(HGCommandInfos e);
        private event CommandExecuted OnCommandExecuted;

        public HGCommandsController(HGMinigame configuration, CommandContext ctx)
        {
            hgMinigame = configuration;
            context = ctx;

            OnCommandExecuted += CommandExecuteAsync;
            context.Client.MessageCreated += CommandsMessage;
        }
        private async Task CommandsMessage(DiscordClient sender, MessageCreateEventArgs e)
        {
            if (e.Channel != hgMinigame.ChannelsController.GameChannel && string.IsNullOrEmpty(e.Message.Content) && e.Author.IsBot)
                return;

            string[] commandArguments = e.Message.Content.Split(' ');
            switch (commandArguments[0])
            {
                case "//info":
                    await OnCommandExecuted?.Invoke(new HGCommandInfos() { CommandID = 1, CommandArguments = commandArguments });
                    break;
            }
        }

        //================================================//

        private async Task CommandExecuteAsync(HGCommandInfos e)
        {
            switch (e.CommandID)
            {
                case 1: //Info Command
                    await ObjectInfosAsync(e.CommandArguments);
                    break;
            }
        }
        public async Task CloseAsync()
        {
            context.Client.MessageCreated -= CommandsMessage;
            await Task.CompletedTask;
        }

        //================================================//
        private async Task ObjectInfosAsync(string[] arguments)
        {
            string objectSelected = arguments[1];
            int elementNum = int.Parse(objectSelected);

            HGPlayer playerSelected = null;

            playerSelected = hgMinigame.PlayersController.TotalPlayers[elementNum];
            await hgMinigame.ChannelsController.GameChannel.SendMessageAsync(PlayerEmbedInfos(playerSelected));

            DiscordEmbedBuilder PlayerEmbedInfos(HGPlayer player)
            {
                string friendsList = "";
                string itensList = "";
                string lastPeopleViewed = "";

                if (player.HaveFriends)
                {
                    foreach (HGFriend friend in player.Friends)
                    {
                        friendsList += $"\n● **{friend.PlayerFriend.Name}** (Intimidade: {friend.RelationShipPercentage}%).";
                    }
                }
                else
                {
                    friendsList = "**[None]**";
                }
                if (friendsList.Length > 2000)
                {
                    friendsList = "**[Essa lista passou de 2000 caracteres]**";
                }


                if (player.Inventory.HasItems)
                {
                    foreach (HGWeaponItemBase item in player.Inventory.WeaponItems)
                    {
                        itensList += $"**{item.Name}**, ";
                    }

                    foreach (HGDecorativeItemsBase item in player.Inventory.DecorativeItems)
                    {
                        itensList += $"**{item.Name}**, ";
                    }
                }
                else
                {
                    itensList += "**[None]**";
                }
                if (itensList.Length > 2000)
                {
                    itensList = "**[Essa lista passou de 2000 caracteres]**";
                }


                if (player.LastPlayerSeen != null)
                {
                    lastPeopleViewed = $"**{player.LastPlayerSeen.Name}**";
                }
                else
                {
                    lastPeopleViewed = "**[None]**";
                }

                DiscordEmbedBuilder embedResult = new DiscordEmbedBuilder();

                embedResult.WithTitle(":scroll: ● INFOMRAÇÕES DE JOGADOR ● :scroll:");
                embedResult.WithDescription(
                                  $"Aqui está as informações do **{player.Name}**. \n\n" +

                                  $"Nome: **{player.Name}** ● Idade: **{player.Age}** \n" +
                                  $"Vida: **{player.CurrentHealth}/{player.MaxHealth}** ● Felicidade: **{player.CurrentHappiness}/{player.MaxHappiness}** ● Sanidade: **{player.CurrentSanity}/{player.MaxSanity}** ● Força: **{player.Force + player.ExtraForce}** \n\n" +

                                  $"▸ Chance de Fazer uma ação normal: **{player.ChanceToNormalAction}%** \n" +
                                  $"▸ Chance de Atacar: **{player.ChanceToAttack}%** \n" +
                                  $"▸ Chance de Fazer Amigos: **{player.ChanceToMakeFriend}%** \n" +
                                  $"▸ Chance de Suicidio: **{player.ChanceToSuicide}%** \n" +
                                  $"▸ Chance de achar um Item: **{player.ChanceToFindingItem}%** \n\n" +

                                  $"Ultima pessoa vista: {lastPeopleViewed} \n" +
                                  $"Amigos: {friendsList} \n\n" +
                                  $"Itens: {itensList}");

                return embedResult;
            }
        }
    }

    public class HGCommandInfos
    {
        public int CommandID { get; set; }
        public string[] CommandArguments { get; set; }
    }
}
