using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarArisingBot.MinigameEngine;
using DSharpPlus;
using DSharpPlus.Entities;
using System.Threading;

namespace StarArisingBot.Minigames.MicroRPG
{
    public class RPGMinigame : MinigameModule
    {
        public RPGChannelsController ChannelsController { get; private set; }
        public RPGMessagesController MessagesController { get; private set; }
        public RPGPlayersController PlayersController { get; private set; }
        public RPGCommandsController CommandsController { get; private set; }
        public RPGRoundController RoundController { get; private set; }


        //==============//
        protected override async Task OnStarted(params dynamic[] minigameParams)
        {
            DiscordMessage loadingMessage = await Context.Channel.SendMessageAsync("<a:loading:856953201740087336> **AGUARDE, ESTOU CONSTRUINDO O MINIGAME**");

            await BuildControllersAsync();
            await BuildChannelsAsync(minigameParams[0]);
            await BuildPlayersAsync();

            await loadingMessage.ModifyAsync("⭐ • **O MINIGAME ESTÁ PRONTO, VÃO TODOS PARA OS SEUS CANAIS!** • ⭐");

            //====================//

            await MinigameFlow();
        }
        protected override async Task OnFinalized()
        {
            await Task.CompletedTask;
        }

        //==============//
        //Build Minigame//
        //==============//
        private async Task BuildControllersAsync()
        {
            ChannelsController = new RPGChannelsController(this, Context);
            MessagesController = new RPGMessagesController(this, Context);
            PlayersController = new RPGPlayersController(this, Context);
            CommandsController = new RPGCommandsController(this, Context);
            RoundController = new RPGRoundController(this, Context);

            await Task.CompletedTask;
        }
        private async Task BuildChannelsAsync(IEnumerable<DiscordMember> members)
        {
            await ChannelsController.SetCategoryChannelAsync(await Context.Guild.CreateChannelCategoryAsync("🏹 • MICRO RPG • 🏹", null, null));

            //=====================//

            List<RPGChannel> playersChannels = new();
            foreach (var member in members)
            {
                RPGChannel channel = new();

                channel.Author = member;
                channel.Channel = await Context.Guild.CreateChannelAsync($"canal-do-{member.Username}", ChannelType.Text, ChannelsController.CategoryChannel, null, null, null, null);

                playersChannels.Add(channel);
            }

            //=====================//

            await ChannelsController.SetPlayersChannelAsync(playersChannels);
        }
        private async Task BuildPlayersAsync()
        {
            List<RPGPlayer> players = new();

            foreach (var channel in ChannelsController.PlayersChannels)
            {
                RPGPlayer player = new(channel.Channel, channel.Author);
                player.SetPlayerStatus();

                players.Add(player);
            }

            await PlayersController.BuildPlayersAsync(players);
        }


        //========//
        //Minigame//
        //========//
        private async Task MinigameFlow()
        {
            await MessagesController.SendIntroMessageAsync();

            Thread.Sleep(5000);

            while (true)
            {
                await MessagesController.SendRoundMessageAsync();
            }

            await FinalizeMinigameAsync();
        }
    }
}