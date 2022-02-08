using System;
using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class InteractionsMessagePack : HGBaseMessagePack
    {
        protected override void BuildPack()
        {
            QuickInteractions();
            MeetingsInteractions();
            FriendshipsInteraction();
            RelationshipInteraction();
        }

        private void QuickInteractions() //Eventos e pensamentos rapidos
        {
            if (Configuration.WorldController.IsDay) //Interações do dia
            {
                messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** observa **{PlayerTarget2.Name}** do acampamento dele.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** encontra o acampamento de **{PlayerTarget2.Name}**.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** anda pelado pela floresta, **{PlayerTarget2.Name}** vê mas prefere não incomodar.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** encontra algumas pegadas que o leva para o acampamento de **{PlayerTarget2.Name}**.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** pensa ter visto **{PlayerTarget2.Name}** o observando.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** furtivamente observa **{PlayerTarget2.Name}** ao longe.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** sente que **{PlayerTarget2.Name}** está aprontando algo.", HGMessageType.DayAction),
                });

                //Se ele conhecer mais de uma pessoa
                if (PlayerTarget1.ViewedPlayers.Count > 0)
                {
                    messages.AddRange(new HGMessage[] {
                        new HGMessage($"**{PlayerTarget1.Name}** pensa se **{PlayerTarget1.GetRandomViwedPlayer().Name}** poderia ser um amigo.", HGMessageType.DayAction),
                        new HGMessage($"**{PlayerTarget1.Name}** pensa se **{PlayerTarget1.GetRandomViwedPlayer().Name}** ainda está vivo.", HGMessageType.DayAction),
                        new HGMessage($"**{PlayerTarget1.Name}** pensa se teria uma chance com **{PlayerTarget1.GetRandomViwedPlayer().Name}**.", HGMessageType.DayAction),
                        new HGMessage($"**{PlayerTarget1.Name}** imagina se **{PlayerTarget1.GetRandomViwedPlayer().Name}** já matou alguém.", HGMessageType.DayAction),
                    });
                }
            }
            else //Interações da noite
            {
                messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** pensa ter visto **{PlayerTarget2.Name}** na floresta.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** ouve a voz do **{PlayerTarget2.Name}** ao longe.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** ouve **{PlayerTarget2.Name}** conversando com mais alguém.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** escondido vê **{PlayerTarget2.Name}** indo em direção a um acampamento.", HGMessageType.NightAction),
                });

                //Se ele conhecer mais de uma pessoa
                if (PlayerTarget1.ViewedPlayers.Count > 0)
                {
                    messages.AddRange(new HGMessage[] {
                       new HGMessage($"**{PlayerTarget1.Name}** pensa se teria uma chance com **{PlayerTarget1.GetRandomViwedPlayer().Name}**.", HGMessageType.NightAction),
                        new HGMessage($"**{PlayerTarget1.Name}** tem pensamentos românticos com **{PlayerTarget1.GetRandomViwedPlayer().Name}**.", HGMessageType.NightAction),
                        new HGMessage($"**{PlayerTarget1.Name}** pensa se **{PlayerTarget1.GetRandomViwedPlayer().Name}** poderia trai-lo.", HGMessageType.NightAction),
                        new HGMessage($"**{PlayerTarget1.Name}** pensa se **{PlayerTarget1.GetRandomViwedPlayer().Name}** seria uma boa companhia.", HGMessageType.NightAction),
                        new HGMessage($"**{PlayerTarget1.Name}** pensa em fazer uma aliança com **{PlayerTarget1.GetRandomViwedPlayer().Name}** em breve.", HGMessageType.NightAction),
                        new HGMessage($"**{PlayerTarget1.Name}** pensa em fazer amizade com **{PlayerTarget1.GetRandomViwedPlayer().Name}**.", HGMessageType.NightAction),
                    });
                }
            }

            PlayerTarget1.AddPlayerViewed(PlayerTarget2);
        }
        private void MeetingsInteractions() //Eventos de encontros aleatorios
        {
            if (Configuration.WorldController.IsDay)
            {
                messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** encontra **{PlayerTarget2.Name}** caminhando na floresta, os dois se encaram.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** tenta conversar com **{PlayerTarget2.Name}** que corre desesperado em direção a floresta.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** vê **{PlayerTarget2.Name}** na praia.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** ouve sons de galhos balançando, ao olhar para cima, **{PlayerTarget1.Name}** vê **{PlayerTarget2.Name}** pulando de galho em galho.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** encontra **{PlayerTarget2.Name}** desmaiado com marcas de pedradas em sua face.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** corre atrás de **{PlayerTarget2.Name}**, mas acaba o perdendo de vista.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** e **{PlayerTarget2.Name}** lutam por uma bolsa de suprimentos. **{PlayerTarget1.Name}** desiste e recua.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** rouba **{PlayerTarget2.Name}** enquanto ele não estava olhando.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** desvia a atenção de **{PlayerTarget2.Name}** e foge.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** rouba itens de **{PlayerTarget2.Name}** enquanto ele não estava olhando.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** persegue **{PlayerTarget2.Name}** pela floresta.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** implora para que **{PlayerTarget2.Name}** o mate, mas **{PlayerTarget2.Name}** recusa o mantendo vivo.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** e **{PlayerTarget2.Name}** batalham por comida, mas **{PlayerTarget1.Name}** desiste e vai embora.", HGMessageType.DayAction),
                });
            }
            else
            {
                messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** encontra **{PlayerTarget2.Name}** caminhando na praia.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** vê **{PlayerTarget2.Name}** matando alguma coisa ao longe.", HGMessageType.NightAction),
                    new HGMessage($@"**{PlayerTarget1.Name}** nota um papel no chão escrito ""**{PlayerTarget2.Name}**"" com Sangue.", HGMessageType.NightAction),
                });
            }

            PlayerTarget1.LastPlayerSeen = PlayerTarget2;
            PlayerTarget2.LastPlayerSeen = PlayerTarget1;

            PlayerTarget1.AddPlayerViewed(PlayerTarget2);
            PlayerTarget2.AddPlayerViewed(PlayerTarget1);
        }
        private void FriendshipsInteraction() //Começando amizades
        {
            if (Configuration.WorldController.IsDay) //Mensagens do dia
            {
                messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** vê **{PlayerTarget2.Name}** ferido andando na floresta, **{PlayerTarget1.Name}** corre em direção a ele para ajudar.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** olha de forma carinhosa para **{PlayerTarget2.Name}** que retribui um pouco do afeto.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** acompanha **{PlayerTarget2.Name}** até seu acampamento.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** entrega uma rosa de presente para **{PlayerTarget2.Name}**.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** conversa um pouco com **{PlayerTarget2.Name}** antes de sair de sua barraca.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** pergunta a **{PlayerTarget2.Name}** se poderiam formar uma aliança, **{PlayerTarget2.Name}** aceita.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** conversa com **{PlayerTarget2.Name}** sobre o passado.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** e **{PlayerTarget2.Name}** conversam sobre planos de ataque.", HGMessageType.DayAction),
                    new HGMessage($"**{PlayerTarget1.Name}** e **{PlayerTarget2.Name}** vão caçar na floresta.", HGMessageType.DayAction),
                });
            }
            else //Mensagens da noite
            {
                messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** convida **{PlayerTarget2.Name}** para seu acampamento passar a noite, ele aceita.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** convence **{PlayerTarget2.Name}** a dormir de conchinha com ele.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** encontra **{PlayerTarget2.Name}** caído na praia, com preocupação ele socorre **{PlayerTarget2.Name}**.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** pergunta a **{PlayerTarget2.Name}** se eles podem ser amigos.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** e **{PlayerTarget2.Name}** conversam sobre o próximo dia.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** e **{PlayerTarget2.Name}** dividem seus suprimentos entre si.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** e **{PlayerTarget2.Name}** se deitam juntos a noite.", HGMessageType.NightAction),
                    new HGMessage($"**{PlayerTarget1.Name}** e **{PlayerTarget2.Name}** contam histórias para acalmar o clima.", HGMessageType.NightAction),
                });
            }

            PlayerTarget1.LastPlayerSeen = PlayerTarget2;
            PlayerTarget2.LastPlayerSeen = PlayerTarget1;

            PlayerTarget1.AddPlayerViewed(PlayerTarget2);
            PlayerTarget2.AddPlayerViewed(PlayerTarget1);

            PlayerTarget1.AddFriend(PlayerTarget2);
            PlayerTarget1.AddFriend(PlayerTarget1);
        }
        private void RelationshipInteraction() //Eventos de Amigos
        {
            if (PlayerTarget1.HaveFriends)
            {
                HGFriend friendSelectedInfos = PlayerTarget1.GetRandomFriend();
                HGPlayer playerFriendSelected = friendSelectedInfos.PlayerFriend;

                if (Configuration.WorldController.IsDay) //Mensagens do Dia
                {
                    switch (friendSelectedInfos.RelationShipPercentage) //Nivel de Intimidade
                    {
                        case < 10: //Conhecidos
                            messages.AddRange(new HGMessage[] {
                                new HGMessage($"**{PlayerTarget1.Name}** fica em sua barraca conversando com **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** anda ao lado de **{playerFriendSelected.Name}** na floresta.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** conta um pouco de sua infância para **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                            });
                            break;

                        case < 30: //Amigos
                            messages.AddRange(new HGMessage[] {
                                new HGMessage($"**{PlayerTarget1.Name}** conta piadas para **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** diz que vai ficar tudo bem **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** tenta acalmar **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** diz para **{playerFriendSelected.Name}** seu maior sonho.", HGMessageType.DayAction),
                            });
                            break;

                        case < 60: //Próximos
                            messages.AddRange(new HGMessage[] {
                                new HGMessage($"**{PlayerTarget1.Name}** diz que não deixará nada acontecer com ele **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** abraça **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** entrega sua arma para **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** ensina técnicas de luta para **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** convida **{playerFriendSelected.Name}** para treinar junto dele.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** pergunta para **{playerFriendSelected.Name}** se ele confia nele.", HGMessageType.DayAction),
                            });
                            break;

                        case < 100: //Irmãos
                            messages.AddRange(new HGMessage[] {
                                new HGMessage($"**{PlayerTarget1.Name}** convida para caçar **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** diz para **{playerFriendSelected.Name}** que ele é como irmão para ele.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** pergunta para **{playerFriendSelected.Name}** se depois dos jogos eles ainda se veriam.", HGMessageType.DayAction),
                                new HGMessage($"**{PlayerTarget1.Name}** entrega seu ultimo pão para **{playerFriendSelected.Name}**.", HGMessageType.DayAction),
                            });
                            break;
                    }
                }
                else //Mensagens da noite
                {
                    switch (friendSelectedInfos.RelationShipPercentage) //Nivel de Intimidade
                    {
                        case < 10: //Conhecidos
                            messages.AddRange(new HGMessage[] {
                                new HGMessage($"**{PlayerTarget1.Name}** convida **{playerFriendSelected.Name}** para dormir com ele.", HGMessageType.NightAction),
                                new HGMessage($"**{PlayerTarget1.Name}** dizem um para o outro **{playerFriendSelected.Name}** como será o futuro.", HGMessageType.NightAction),
                            });
                            break;

                        case < 30: //Amigos
                            messages.AddRange(new HGMessage[] {
                                new HGMessage($"**{PlayerTarget1.Name}** e **{playerFriendSelected.Name}** contam histórias de fantasma para aliviar o clima.", HGMessageType.NightAction),
                                new HGMessage($"**{PlayerTarget1.Name}** diz para **{playerFriendSelected.Name}** seu sonho de vida.", HGMessageType.NightAction),
                                new HGMessage($"**{PlayerTarget1.Name}** pergunta para **{playerFriendSelected.Name}** se ele realmente gosta de ele.", HGMessageType.NightAction),
                            });
                            break;

                        case < 100: //Próximos
                            messages.AddRange(new HGMessage[] {
                                new HGMessage($"**{PlayerTarget1.Name}** diz que irá honrar **{playerFriendSelected.Name}** nos jogos.", HGMessageType.NightAction),
                                new HGMessage($"**{PlayerTarget1.Name}** diz para **{playerFriendSelected.Name}** que fará tudo para protegê-lo.", HGMessageType.NightAction),
                                new HGMessage($"**{PlayerTarget1.Name}** relembra **{playerFriendSelected.Name}** que no final eles terão que se matar para vencer os jogos.", HGMessageType.NightAction),
                                new HGMessage($"**{PlayerTarget1.Name}** se apoia nos ombros gelados de **{playerFriendSelected.Name}**.", HGMessageType.NightAction),
                                new HGMessage($"**{PlayerTarget1.Name}** chora nos ombros de **{playerFriendSelected.Name}**.", HGMessageType.NightAction),
                                new HGMessage($"**{PlayerTarget1.Name}** conta seus segredos mais íntimos para **{playerFriendSelected.Name}**.", HGMessageType.NightAction),
                            });
                            break;
                    }
                }

                //Troca de itens
                if (PlayerTarget1.Inventory.HasItems)
                {
                    HGWeaponItemBase target1WeaponItemSelected = null;
                    HGDecorativeItemsBase target1DecorativeItemSelected = null;

                    if (PlayerTarget1.Inventory.TotalWeaponsCount > 0) target1WeaponItemSelected = PlayerTarget1.Inventory.GetRandomItem<HGWeaponItemBase>();
                    if (PlayerTarget1.Inventory.TotalDecorativeCount > 0) target1DecorativeItemSelected = PlayerTarget1.Inventory.GetRandomItem<HGDecorativeItemsBase>();
                    HGItemType itemType = HGItemType.None;

                    if (new Random().Next(1, 100) < 50) //Itens de Ataque
                    {
                        if (target1WeaponItemSelected == null)
                            return;

                        PlayerTarget1.Inventory.RemoveItem(target1WeaponItemSelected);
                        PlayerTarget2.Inventory.AddItem(target1WeaponItemSelected);

                        itemType = HGItemType.Weapon;
                    }
                    else //Itens decorativos
                    {
                        if (target1DecorativeItemSelected == null)
                            return;

                        PlayerTarget1.Inventory.RemoveItem(target1DecorativeItemSelected);
                        PlayerTarget2.Inventory.AddItem(target1DecorativeItemSelected);

                        itemType = HGItemType.Descoration;
                    }

                    switch (itemType)
                    {
                        case HGItemType.Weapon:
                            AddMessage(Configuration.WorldController.IsDay, itemType);
                            break;

                        case HGItemType.Descoration:
                            AddMessage(Configuration.WorldController.IsDay, itemType);
                            break;
                    }

                    void AddMessage(bool isDay, HGItemType type)
                    {
                        List<HGMessage> tempMessages = new List<HGMessage>();

                        for (int i = 0; i < PlayerTarget1.Inventory.TotalItemsCount; i++)
                        {
                            if (isDay)
                            {
                                switch (type)
                                {
                                    case HGItemType.Weapon:
                                        tempMessages.Add(new HGMessage($"**{PlayerTarget1.Name}** entregua {target1WeaponItemSelected.PossessivePronoun} {target1WeaponItemSelected.Name} para **{playerFriendSelected.Name}**.", HGMessageType.DayAction));
                                        break;
                                    case HGItemType.Descoration:
                                        tempMessages.Add(new HGMessage($"**{PlayerTarget1.Name}** entregua {target1DecorativeItemSelected.PossessivePronoun} {target1DecorativeItemSelected.Name} para **{playerFriendSelected.Name}**.", HGMessageType.DayAction));
                                        break;
                                }
                            }
                            else
                            {
                                switch (type)
                                {
                                    case HGItemType.Weapon:
                                        tempMessages.Add(new HGMessage($"**{PlayerTarget1.Name}** entregua **{target1WeaponItemSelected.PossessivePronoun} {target1WeaponItemSelected.Name}** para **{playerFriendSelected.Name}**.", HGMessageType.NightAction));
                                        break;
                                    case HGItemType.Descoration:
                                        tempMessages.Add(new HGMessage($"**{PlayerTarget1.Name}** entregua **{target1DecorativeItemSelected.PossessivePronoun} {target1DecorativeItemSelected.Name}** para **{playerFriendSelected.Name}**.", HGMessageType.NightAction));
                                        break;
                                }
                            }
                        }

                        messages.AddRange(tempMessages);
                    }
                }

                PlayerTarget1.AddFriend(playerFriendSelected);
                PlayerTarget2.AddFriend(PlayerTarget1);
            }
        }
    }
}
