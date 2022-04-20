using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using StarArisingBot.MinigameEngine;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.HungerGames
{
    public enum PlayersBuildType
    {
        PerNumbers,
        PerUsers,
    }

    public class HGMinigame : MinigameModule
    {
        public HGPlayersController PlayersController { get; private set; }
        public HGChannelsController ChannelsController { get; private set; }
        public HGMessagesController MessagesController { get; private set; }
        public HGWorldController WorldController { get; private set; }
        public HGItemsController ItemsController { get; private set; }
        public HGCommandsController CommandsController { get; private set; }

        private List<DiscordUser> UsersAmount { get; set; }
        private int PlayersAmount { get; set; }

        protected override async Task OnStarted(params dynamic[] minigameParams)
        {
            PlayersController = new HGPlayersController(this, Context);
            MessagesController = new HGMessagesController(this, Context);
            ItemsController = new HGItemsController(this, Context);
            CommandsController = new HGCommandsController(this, Context);

            ChannelsController = new HGChannelsController();
            WorldController = new HGWorldController();

            await StartAsync(minigameParams[0]);
        }
        protected override async Task OnFinalized()
        {
            await CommandsController.CloseAsync();

            Thread.Sleep(100000);
            await ChannelsController.GameChannel.DeleteAsync();
            await ChannelsController.GameCategory.DeleteAsync();
        }

        //============================================//

        private async Task StartAsync(int amount)
        {
            PlayersAmount = amount;

            BuildPlayers(PlayersBuildType.PerNumbers);
            await BuildChannelsAsync();

            await FinalConfigAsync();
        }
        private async Task StartAsync(IEnumerable<DiscordUser> users)
        {
            UsersAmount = new List<DiscordUser>(users);

            BuildPlayers(PlayersBuildType.PerUsers);
            await BuildChannelsAsync();

            await FinalConfigAsync();
        }
        private async Task StartAsync(IEnumerable<DiscordMember> members)
        {
            UsersAmount = new List<DiscordUser>(members);

            BuildPlayers(PlayersBuildType.PerUsers);
            await BuildChannelsAsync();

            await FinalConfigAsync();
        }

        private async Task FinalConfigAsync()
        {
            await Context.Channel.SendMessageAsync($"\n**ESTÁ TUDO PRONTO** \nVão para o canal <#{ChannelsController.GameChannel.Id}>");

            await MessagesController.StartMessage();
            await GameStartAsync();
        }

        private void BuildPlayers(PlayersBuildType buildType)
        {
            switch (buildType)
            {
                case PlayersBuildType.PerNumbers:
                    for (int i = 0; i < PlayersAmount; i++)
                    {
                        HGPlayer player = new HGPlayer();
                        player.Randomizer();

                        player.Name += $" #{i}";
                        player.ID = i;
                        PlayersController.TotalPlayers.Add(player);
                    }
                    break;

                case PlayersBuildType.PerUsers:
                    for (int i = 0; i < UsersAmount.Count; i++)
                    {
                        HGPlayer player = new HGPlayer();
                        player.Randomizer();

                        player.Name = $"{UsersAmount[i].Username} #{i}";
                        player.ID = i;
                        PlayersController.TotalPlayers.Add(player);
                    }
                    break;
            }

            PlayersController.SetLivingPlayers(new List<HGPlayer>(PlayersController.TotalPlayers));
        }
        private async Task BuildChannelsAsync()
        {
            ChannelsController.SetGameCategoryChannel(await Context.Guild.CreateChannelCategoryAsync("🏹 ▸ HUNGER GAMES ◂ 🏹"));
            ChannelsController.SetGameChannel(await Context.Guild.CreateChannelAsync("🏹-》hunger-games", ChannelType.Text, ChannelsController.GameCategory, "Welcome do Hunger Games Simulator, See this huge heart-shaking event"));
        }

        //============================================//

        private async Task GameStartAsync()
        {
            try
            {
                //Ainda há jogadores vivos
                while (PlayersController.LivingPlayers.Count > 1)
                {
                    Thread.Sleep(2000);

                    //Enviar mensagem do estado atual do dia
                    if (WorldController.IsDay)
                    {
                        await ChannelsController.GameChannel.SendMessageAsync(MessagesController.NewDayMessage());
                        Thread.Sleep(2000);

                        //Jogadores vivos
                        await ChannelsController.GameChannel.SendMessageAsync(MessagesController.LivingPlayersListMessage());
                    }
                    else
                    {
                        await ChannelsController.GameChannel.SendMessageAsync(MessagesController.NewNightMessage());
                    }

                    Thread.Sleep(5000);

                    //Ainda há dialogos faltando
                    while (WorldController.RemainingDialogues > 0)
                    {
                        if (PlayersController.LivingPlayers.Count == 1)
                            break;

                        await ChannelsController.GameChannel.SendMessageAsync(MessagesController.PlayerActionMessage());
                        WorldController.RemainingDialogues--;

                        Thread.Sleep(5000);
                    }

                    WorldController.SwapDayState();

                    if (WorldController.IsDay) WorldController.CurrentDay++;
                }
            }
            catch (Exception e)
            {
                await ChannelsController.GameChannel.SendMessageAsync(e.ToString());
            }

            await ChannelsController.GameChannel.SendMessageAsync(MessagesController.PlayerWinsMessage());
            await FinalizeMinigameAsync();
        }

        //============================================//
    }
}
