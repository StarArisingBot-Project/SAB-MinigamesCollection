using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using StarArisingBot.MinigameEngine;
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

            await Start(minigameParams[0]);
        }
        protected override async Task OnFinalized()
        {
            await CommandsController.CloseAsync();

            Thread.Sleep(100000);
            await ChannelsController.GameChannel.DeleteAsync();
            await ChannelsController.GameCategory.DeleteAsync();
        }

        //============================================//

        private async Task Start(int amount)
        {
            PlayersAmount = amount;

            BuildPlayers(PlayersBuildType.PerNumbers);
            await BuildChannels();

            await FinalConfigAsync();
        }
        private async Task Start(IEnumerable<DiscordUser> users)
        {
            UsersAmount = new List<DiscordUser>(users);

            BuildPlayers(PlayersBuildType.PerUsers);
            await BuildChannels();

            await FinalConfigAsync();
        }
        private async Task Start(IEnumerable<DiscordMember> members)
        {
            UsersAmount = new List<DiscordUser>(members);

            BuildPlayers(PlayersBuildType.PerUsers);
            await BuildChannels();

            await FinalConfigAsync();
        }

        private async Task FinalConfigAsync()
        {
            await Context.Channel.SendMessageAsync($"\n**ESTÁ TUDO PRONTO** \nVão para o canal <#{ChannelsController.GameChannel.Id}>");
            await MessagesController.Start();
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
        private async Task BuildChannels()
        {
            ChannelsController.SetGameCategoryChannel(await Context.Guild.CreateChannelCategoryAsync("🏹 ▸ HUNGER GAMES ◂ 🏹"));
            ChannelsController.SetGameChannel(await Context.Guild.CreateChannelAsync("🏹-》hunger-games", ChannelType.Text, ChannelsController.GameCategory, "Welcome do Hunger Games Simulator, See this huge heart-shaking event"));
        }

        //============================================//
        public async Task EndMinigame()
        {
            await FinalizeMinigameAsync();
        }
    }
}
