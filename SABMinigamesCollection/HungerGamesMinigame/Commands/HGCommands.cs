﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarArisingBot.MinigameEngine;
using DSharpPlus.Interactivity;
using DSharpPlus.EventArgs;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGCommands : BaseCommandModule
    {
        [Command("HungerGames"), Aliases("HG", "JogosVorazes", "JV")]
        public async Task HungerGames(CommandContext ctx)
        {
            MinigameSessionBuilder sessionBuilder = new MinigameSessionBuilder()
            {
                AuthorType = MinigameSessionAuthorType.Guild,
                InvokeType = MinigameSessionInvokeType.Guild,
            };

            if (await MinigameInstanceClient.GetInstanceAsync(typeof(HGMinigame)).Result.GetSessionAsync(ctx.Guild.Id) != null)
            {
                await ctx.RespondAsync($"<@{ctx.User.Id}> **JÁ ESTÁ OCORRENDO UM HUNGER GAMES NO SERVIDOR, ESPERE TERMINAR ANTES DE COMEÇAR OUTRO**");
                return;
            }

            DiscordEmoji[] actionsEmojis =
            {
                DiscordEmoji.FromName(ctx.Client, ":zero:"),
                DiscordEmoji.FromName(ctx.Client, ":one:"),
                DiscordEmoji.FromName(ctx.Client, ":two:"),
                DiscordEmoji.FromName(ctx.Client, ":three:"),
            };

            DiscordEmbedBuilder startEmbed = new DiscordEmbedBuilder()
            {
                Title = ":crossed_swords: ● JOGOS VORAZES ● :crossed_swords:",
                Description = "Seja bem-vindo ao **Simulador dos jogos Vorazes**! Crie partidas **Tensas, Emocionantes e de Abalar Corações** com este simulador. \n\n" +
                              "Antes de começar, escolha abaixo como será a seleção de jogadores: \n\n" +
                              ":zero: ● **All** ➤ O Bot irá selecionar todos os membros do servidor (Com excessão de bots). \n" +
                              ":one: ● **Bots** ➤ O Bot irá selecionar todos os membros que são bots no servidor. \n" +
                              ":two: ● **NPCs** ➤ O Bot irá criar seus proprios NPCs para os jogos vorazes. \n" +
                              ":three: ● **Select** ➤ Selecione apenas membros desejados. \n\n" +
                              "*Clique em uma das reações abaixo para continuar.*",
                Color = DiscordColor.Green,
            };
            DiscordMessage currentMessage = await ctx.Channel.SendMessageAsync(startEmbed);

            await currentMessage.CreateReactionAsync(actionsEmojis[0]);
            await currentMessage.CreateReactionAsync(actionsEmojis[1]);
            await currentMessage.CreateReactionAsync(actionsEmojis[2]);
            await currentMessage.CreateReactionAsync(actionsEmojis[3]);

            InteractivityResult<MessageReactionAddEventArgs> reactionResult = await currentMessage.WaitForReactionAsync(ctx.Member, TimeSpan.FromSeconds(20));
            if (!reactionResult.TimedOut)
            {
                if (reactionResult.Result.Emoji == actionsEmojis[0])
                {
                    await SendStartMessage();
                    await MinigameInstanceClient.GetInstanceAsync(typeof(HGMinigame)).Result.CreateNewSessionAsync(ctx, new HGMinigame(), sessionBuilder, new List<DiscordMember>(ctx.Guild.Members.Values.Where(x => !x.IsBot).ToList()));
                }
                else if (reactionResult.Result.Emoji == actionsEmojis[1])
                {
                    await SendStartMessage();
                    await MinigameInstanceClient.GetInstanceAsync(typeof(HGMinigame)).Result.CreateNewSessionAsync(ctx, new HGMinigame(), sessionBuilder, new List<DiscordMember>(ctx.Guild.Members.Values.Where(x => x.IsBot).ToList()));
                }
                else if (reactionResult.Result.Emoji == actionsEmojis[2])
                {
                    int amount = 0;
                    await ctx.Channel.SendMessageAsync($"<@{ctx.User.Id}> **Quantos npcs estarão participando?** \n" +
                                                       $"*(Digite apenas numeros)*");

                    InteractivityResult<DiscordMessage> result = ctx.Channel.GetNextMessageAsync(ctx.User, TimeSpan.FromSeconds(20)).Result;
                    if (!result.TimedOut)
                    {
                        try
                        {
                            amount = int.Parse(result.Result.Content);
                        }
                        catch (Exception)
                        {
                            await ctx.Channel.SendMessageAsync("**OH NÃO, PARECE QUE ALGO DEU ERRADO** \n" +
                                                              $"<@{ctx.User.Id}> **Verifique se você escreveu corretamente o numero, caso esteja em duvida, veja se você passou por estas condições:** \n" +
                                                              $"● Não digite numeros Negativos ou Valores absurdos. \n" +
                                                              $"● Não digite palavras. \n" +
                                                              $"● Não digite espaços. \n" +
                                                              $"● Não envie arquivos anexados.");

                            return;
                        }
                    }

                    await SendStartMessage();
                    await MinigameInstanceClient.GetInstanceAsync(typeof(HGMinigame)).Result.CreateNewSessionAsync(ctx, new HGMinigame(), sessionBuilder, amount);
                }
                else if (reactionResult.Result.Emoji == actionsEmojis[3])
                {
                    List<DiscordUser> members = new();
                    await ctx.Channel.SendMessageAsync($"**<@{ctx.User.Id}> MENCIONE OS MEMBROS QUE IRÃO PARTICIPAR DO JOGO.** \n" +
                                                       $"*(Apenas menções)*");

                    InteractivityResult<DiscordMessage> result = ctx.Channel.GetNextMessageAsync(ctx.User, TimeSpan.FromSeconds(20)).Result;
                    if (!result.TimedOut)
                    {
                        try
                        {
                            members = new List<DiscordUser>(result.Result.MentionedUsers);
                        }
                        catch (Exception)
                        {
                            await ctx.Channel.SendMessageAsync("**OH NÃO, PARECE QUE ALGO DEU ERRADO** \n" +
                                                              $"<@{ctx.User.Id}> **Verifique se você escreveu corretamente, caso esteja em duvida, veja se você passou por estas condições:** \n" +
                                                              $"● Digite apenas menções. \n" +
                                                              $"● Deixe um pequeno espaço entre as menções.");
                        }

                        await SendStartMessage();
                        await MinigameInstanceClient.GetInstanceAsync(typeof(HGMinigame)).Result.CreateNewSessionAsync(ctx, new HGMinigame(), sessionBuilder, new List<DiscordUser>(members));
                    }
                }
            }

            async Task SendStartMessage()
            {
                await ctx.Channel.SendMessageAsync(":crossed_swords: ● **OS JOGOS VORAZES ESTÃO COMEÇANDO** ● :crossed_swords: \n" +
                                                   "Aguarde enquanto eu Organizo o Evento!");
            }
        }
    }
}
