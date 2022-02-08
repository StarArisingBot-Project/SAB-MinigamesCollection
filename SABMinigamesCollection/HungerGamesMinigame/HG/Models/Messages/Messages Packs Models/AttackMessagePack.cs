using System;
using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class AttackMessagePack : HGBaseMessagePack
    {
        private bool IsTargetFriend = false;

        protected override void BuildPack()
        {
            List<HGPlayer> playersList = new List<HGPlayer>(Configuration.PlayersController.LivingPlayers);
            foreach (HGFriend playerFriend in PlayerTarget1.Friends)
            {
                playersList.Remove(playerFriend.PlayerFriend);
            }
            playersList.Remove(PlayerTarget1);

            if (playersList.Count != 0) PlayerTarget2 = playersList[Random.Next(0, playersList.Count - 1)];
            else IsTargetFriend = true;

            PlayerTarget1.LastPlayerSeen = PlayerTarget2;
            PlayerTarget2.LastPlayerSeen = PlayerTarget1;

            PlayerTarget1.ViewedPlayers.Add(PlayerTarget2);
            PlayerTarget1.ViewedPlayers.Add(PlayerTarget1);

            //Dano no jogador
            PlayerTarget2.CurrentHealth -= PlayerTarget1.Force + PlayerTarget1.ExtraForce + Random.Next(1, 10);
            if (PlayerTarget2.CurrentHealth <= 0)
            {
                MurderActions();

                PlayerTarget1.TotalKills++;
                Configuration.PlayersController.Kill(PlayerTarget2);
                return;
            }

            NormalAttacks();
        }

        private void NormalAttacks()
        {
            //Ataques sem armas
            if (!IsTargetFriend) //Atacando desconhecido
            {
                if (Configuration.WorldController.IsDay) //Ataque de dia
                {
                    messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** encontra **{PlayerTarget2.Name}** andando pela floresta, em um ataque ágil **{PlayerTarget2.Name}** é jogado no chão e recebe vários socos em sua face, mas por sorte consegue fugir.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** com um movimento rápido, pega uma pedra grande do chão e arremessa em direção ao **{PlayerTarget2.Name}** que é acertado com tudo na cabeça, a dor é imensa.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** chuta o rosto de **{PlayerTarget2.Name}** com toda a força que caí desmaiado no chão, alguns minutos depois ele acorda e sente a dor de sua nova fratura.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** usa toda sua força para enforcar **{PlayerTarget2.Name}** o máximo que conseguia, mas após ouvir algumas vozes próximas, **{PlayerTarget1.Name}** larga **{PlayerTarget2.Name}** e vai embora.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** encurrala **{PlayerTarget2.Name}** na floresta e começa a desferir vários socos em seu corpo.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** prende **{PlayerTarget2.Name}** em sua barraca e começa a tortura-lo, no dia seguinte **{PlayerTarget2.Name}** consegue fugir.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** segue **{PlayerTarget2.Name}** até sua barraca onde desfere um ataque surpresa batendo uma pedra em sua cabeça varias vezes.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** consegue ouvir **{PlayerTarget2.Name}** nas proximidades. **{PlayerTarget1.Name}** caminha em direção ao local e encontra **{PlayerTarget2.Name}** caçando animais pequenos, em um movimento rápido {PlayerTarget2.Name} é jogado no chão e acertado várias vezes na cabeça com uma pedra.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** tenta iniciar uma amizade com **{PlayerTarget2.Name}** que não gosta e parte para cima para ataca-lo, **{PlayerTarget1.Name}** consegue se defender e saí correndo dali.", HGMessageType.AttackAction)
                    });
                }
                else //Ataques de noite
                {
                    messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** invade o acampamento de **{PlayerTarget2.Name}**, após alguns segundos ele avista **{PlayerTarget2.Name}** próximo a saída e em um movimento rápido executa um mata-leão que o deixa inconsciente.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** se esconde na mata e espera alguém aparecer, **{PlayerTarget2.Name}** aparece e é acertado por um pedaço de pedra que o derruba do pequeno monte onde eles estavam, suas feridas são grandes.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** se esconde na mata e espera alguém aparecer, **{PlayerTarget2.Name}** aparece e é acertado por um pedaço de pedra que o derruba do pequeno monte onde eles estavam, suas feridas são grandes.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** silenciosamente, caminha até o acampamento de **{PlayerTarget2.Name}** onde preparando para roubar algo, encontra **{PlayerTarget2.Name}** dormindo no chão, ela então aproveita a situação e pega uma pedra grande e começa a bater na cabeça dele muito forte, ao pensar que ele está morto ela vai embora.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** encontra **{PlayerTarget2.Name}** sozinho a noite que é atacado impetuosamente por **{PlayerTarget1.Name}** que o agride durante muito tempo.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** sorrateiramente encontra **{PlayerTarget2.Name}** dormindo sozinho na floresta escura, em um movimento rápido ele começa a ser estrangulado por **{PlayerTarget1.Name}** que, ao se questionar se ele conseguiu mata-lo vai embora..", HGMessageType.AttackAction),
                    });
                }
            }
            else //Atacando amigo
            {
                if (Configuration.WorldController.IsDay)
                {
                    messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** com lagrimas em seus olhos e com o sentimento de traição, chuta e agride **{PlayerTarget2.Name}** o máximo que consegue, depois saí correndo dali.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** com dor em seu coração, empurra **{PlayerTarget2.Name}** ladeira abaixo que por um milagre, consegue sobreviver.", HGMessageType.AttackAction),
                    new HGMessage($"**{PlayerTarget1.Name}** com um sorriso triste, **{PlayerTarget1.Name}** se defende dos ataques de **{PlayerTarget2.Name}** e volta com um soco que consegue desmaia-lo temporariamente, a amizade acabou.", HGMessageType.AttackAction),
                    });
                }
                else
                {
                    messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** invade o acampamento de **{PlayerTarget2.Name}**, após alguns segundos ele avista **{PlayerTarget2.Name}** próximo a saída e em um movimento rápido executa um mata-leão que o deixa inconsciente.", HGMessageType.AttackAction),
                    });
                }
            }

            //Atauqes com armas
            ItemAttackMessages(false);
        }

        //==========================//
        private void MurderActions()
        {
            //Ataques sem armas
            if (!IsTargetFriend) //Se o alvo não for um amigo
            {
                messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** escala uma arvore à espera de alguém passar ali por perto, **{PlayerTarget2.Name}** se aproxima e então **{PlayerTarget1.Name}** salta da arvore e caí em cima dele, depois começa desferir varios socos que acabam sendo mortais.", HGMessageType.MurderAction),

                    new HGMessage($"**{PlayerTarget1.Name}** bate uma pedra no crânio de **{PlayerTarget2.Name}** brutalmente várias vezes, **{PlayerTarget2.Name}** não resiste as fraturas.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** estrangula **{PlayerTarget2.Name}** com toda a sua força até a morte.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** afoga **{PlayerTarget2.Name}** em um lago próximo durante muito tempo, ninguém ouve seus gritos de terror.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** enforca **{PlayerTarget2.Name}** em uma árvore.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** crucificou **{PlayerTarget2.Name}** em uma árvore.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** empala **{PlayerTarget2.Name}** com uma estaca de madeira.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** tortura **{PlayerTarget2.Name}** brutalmente durante muito tempo, ao ficar cansado daquilo, **{PlayerTarget1.Name}** o finaliza..", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** persegue **{PlayerTarget2.Name}** na floresta até encurrala-lo(a), ao ficar sem saída **{PlayerTarget2.Name}** leva vários socos em seu crânio que eventualmente leva a sua morte.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a enfiar terra e areia na boca de **{PlayerTarget2.Name}** que acaba engasgando e morrendo.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** empurra **{PlayerTarget2.Name}** fazendo ele cair em uma pedra muito afiada que atravessa sua cabeça, sua morte é instantânea.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** entrega frutinhas venenosas para **{PlayerTarget2.Name}** que acaba comendo e morrendo intoxicado(a).", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** empurra **{PlayerTarget2.Name}** do penhasco que cai para a morte.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** esmaga o crânio de **{PlayerTarget2.Name}** com um soco.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** violentamente quebra o pescoço de **{PlayerTarget2.Name}**.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** corta brutalmente a barriga de **{PlayerTarget2.Name}**, depois enfia sua mão na grande abertura e aperta o seu coração até explodi-lo.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** convoca **{PlayerTarget2.Name}** para um ritual, mas **{PlayerTarget2.Name}** não sabia que ele era um dos ingredientes.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget1.Name}** acerta uma pedra por engano na cabeça de **{PlayerTarget2.Name}**. \n**{PlayerTarget1.Name}** tenta cura-lo mas acaba falhando. \n**{PlayerTarget2.Name}** morre nos braços de **{PlayerTarget1.Name}** lentamente.", HGMessageType.MurderAction),

                    new HGMessage($"**{PlayerTarget2.Name}** assusta **{PlayerTarget1.Name}**, **{PlayerTarget1.Name}** com raiva  pega uma pedra e bate várias vezes na cabeça de **{PlayerTarget2.Name}** que acaba morrendo eventualmente.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget2.Name}** tenta iniciar uma amizade com **{PlayerTarget1.Name}**, mas acaba falhando e leva vários socos em seu rosto que fazem fraturas gigantes e eventualmente trazem a morte.", HGMessageType.MurderAction),
                    new HGMessage($"**{PlayerTarget2.Name}** encontra o acampamento de **{PlayerTarget1.Name}**, numa tentativa de roubar seus itens, ele é encontrado(a) e morto(a) por **{PlayerTarget1.Name}**.", HGMessageType.MurderAction),
                });
            }
            else //Se o alvo for um amigo
            {
                messages.AddRange(new HGMessage[] {
                      new HGMessage($"**{PlayerTarget1.Name}** com lagrimas em seus olhos, empurra **{PlayerTarget2.Name}** ladeira abaixo que cai para a morte.", HGMessageType.MurderAction),
                      new HGMessage($"**{PlayerTarget1.Name}** com lagrimas em seus olhos, esmaga a cabeça de **{PlayerTarget2.Name}** com uma pedra.", HGMessageType.MurderAction),
                });
            }

            //Ataques com armas
            ItemAttackMessages(true);

            //Jogador Recebe os Items do jogador morto
            PlayerTarget1.Inventory.AddItems(PlayerTarget2.Inventory.WeaponItems);
            PlayerTarget1.Inventory.AddItems(PlayerTarget2.Inventory.DecorativeItems);
        }

        //==========================//
        private void ItemAttackMessages(bool isMurderAction)
        {
            //Ver se o player tem itens e se tem armas
            if (!PlayerTarget1.Inventory.HasItems && PlayerTarget1.Inventory.TotalWeaponsCount <= 0)
                return;

            //Verificações
            for (int i = 0; i < PlayerTarget1.Inventory.TotalWeaponsCount; i++)
            {
                //Selecionar uma arma aleatoria
                HGWeaponItemBase weaponSelected = PlayerTarget1.Inventory.GetRandomItem<HGWeaponItemBase>();

                if (!IsTargetFriend) //Se o alvo não for amigo
                {
                    if (isMurderAction) //Se for uma ação de assassinato
                    {
                        messages.Add(new HGMessage(weaponSelected.GetRandomMurderMessage(PlayerTarget1, PlayerTarget2), HGMessageType.MurderAction));
                    }
                    else //Se for um ataque comum
                    {
                        messages.Add(new HGMessage(weaponSelected.GetRandomAttackMessage(PlayerTarget1, PlayerTarget2), HGMessageType.AttackAction));
                    }
                }
                else //Se o alvo for um amigo
                {
                    if (isMurderAction) //Se for uma ação de assassinato
                    {
                        messages.Add(new HGMessage(weaponSelected.GetRandomMurderFriendMessage(PlayerTarget1, PlayerTarget2), HGMessageType.MurderAction));
                    }
                    else //Se for um ataque comum
                    {
                        messages.Add(new HGMessage(weaponSelected.GetRandomAttackFriendMessage(PlayerTarget1, PlayerTarget2), HGMessageType.AttackAction));
                    }
                }
            }
        }
    }
}
