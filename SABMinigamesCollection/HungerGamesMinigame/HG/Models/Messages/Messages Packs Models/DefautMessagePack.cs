using System;

namespace StarArisingBot.Minigames.HungerGames
{
    public class DefautMessagePack : HGBaseMessagePack
    {
        protected override void BuildPack()
        {
            NormalActions();

            HealthMessages();
            HappinessMessages();
            SanityMessages();
        }

        //Days Events
        private void NormalActions()
        {
            if (Configuration.WorldController.IsDay)
            {
                messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** parte para uma aventura.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToFindingItemModifier = 20 }),
                    new HGMessage($"**{PlayerTarget1.Name}** encontra um pequeno lago.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToFindingItemModifier = 15 }),
                    new HGMessage($"**{PlayerTarget1.Name}** sobe em uma árvore para ver se tem alguém lhe seguindo.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToAttackModifier = 10 }),

                    new HGMessage($"**{PlayerTarget1.Name}** tenta acender uma fogueira mas falha.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -10, ChanceToSuicideModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** passa o dia pescando.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = 5, ChanceToSuicideModifier = -5, SanityModifier = 5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** explora a ilha.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToFindingItemModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** pensa em sua futura casa.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = 5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** desmaia por uma hora.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -5, SanityModifier = -10, ChanceToSuicideModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tenta caçar alguns animais pequenos.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToAttackModifier = 10, HappinessModifier = -10}),
                    new HGMessage($"**{PlayerTarget1.Name}** percebe que tem alguém lhe seguindo.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -5, ChanceToAttackModifier = 10, ChanceToSuicideModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** vai para um lugar distante.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToFindingItemModifier = 20 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a falar sozinho.", HGMessageType.DayAction, new HGMessageEffect() { SanityModifier = -5, HappinessModifier = -5, ChanceToSuicideModifier = 10}),
                    new HGMessage($"**{PlayerTarget1.Name}** começa comer suas próprias roupas.", HGMessageType.DayAction, new HGMessageEffect() { SanityModifier = -10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** dorme algumas horas, mas é despertado(a) por alguns barulhos.", HGMessageType.DayAction, new HGMessageEffect() { SanityModifier = -10, ChanceToSuicideModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** contempla a si mesmo(a).", HGMessageType.DayAction, new HGMessageEffect() { SanityModifier = 10, HappinessModifier = 10, ChanceToSuicideModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** fica perdido(a) na floresta.", HGMessageType.DayAction, new HGMessageEffect() { SanityModifier = -10, HappinessModifier = -10, ChanceToSuicideModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** procura por outros tributos.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToAttackModifier = -5, ChanceToMakeFriendModifier = 10}),
                    new HGMessage($"**{PlayerTarget1.Name}** nota pegadas no chão.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToAttackModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** escreve cartas de socorro.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -10, SanityModifier = -5, ChanceToSuicideModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** encontra cartas de socorro.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -10, SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** passa a tarde inteira na praia da ilha.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = 10, SanityModifier = 10, ChanceToSuicideModifier = -15}),
                    new HGMessage($"**{PlayerTarget1.Name}** grita.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -5, SanityModifier = -15, ChanceToSuicideModifier = 12 }),
                    new HGMessage($"**{PlayerTarget1.Name}** coleta flores.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = 16, SanityModifier = 20, ChanceToSuicideModifier = -12 }),
                    new HGMessage($"**{PlayerTarget1.Name}** enquanto explorava a floresta vê uma câmera.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -10, SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** ouve gritos na distância.", HGMessageType.DayAction, new HGMessageEffect() { SanityModifier = -12, HappinessModifier = -5, ChanceToSuicideModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** descansa pensando nos próximos dias na ilha.", HGMessageType.DayAction, new HGMessageEffect() { SanityModifier = -5, HappinessModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** bebe água de um lago próximo.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** cria forças para sair de seu acampamento.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tenta capturar alguns animais.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToAttackModifier = 16, HappinessModifier = -15 }),
                    new HGMessage($"**{PlayerTarget1.Name}** se esconde no mato.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToAttackModifier = 16 }),
                    new HGMessage($"**{PlayerTarget1.Name}** repensa suas escolhas de vida.", HGMessageType.DayAction, new HGMessageEffect() { SanityModifier = -5, HappinessModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** foi picado(a) por uma serpente. Depois de 2 dias agonizando de dor, finalmente a serpente morreu.", HGMessageType.DayAction),
                });
                ItemMessages(true);
            }
            else
            {
                messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** tenta dormir mas não consegue.", HGMessageType.NightAction, new HGMessageEffect(){ ChanceToSuicideModifier = 20, HappinessModifier = -10, SanityModifier = -5}),
                    new HGMessage($"**{PlayerTarget1.Name}** dorme a noite.", HGMessageType.NightAction, new HGMessageEffect(){ HappinessModifier = 10, SanityModifier = 5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** fica acordado a noite.", HGMessageType.NightAction, new HGMessageEffect(){ HappinessModifier = -10, SanityModifier = -10, ChanceToSuicideModifier = -10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** busca por outros tributos.", HGMessageType.NightAction, new HGMessageEffect(){ ChanceToMakeFriendModifier = 10, ChanceToAttackModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tenta caçar.", HGMessageType.NightAction, new HGMessageEffect(){ ChanceToAttackModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a refletir sobre a vida.", HGMessageType.NightAction, new HGMessageEffect(){ ChanceToSuicideModifier = 5, HappinessModifier = 10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** parte em busca de um local melhor.", HGMessageType.NightAction, new HGMessageEffect(){ ChanceToFindingItemModifier = 5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** batalha contra alguns animais em busca de comida.", HGMessageType.NightAction, new HGMessageEffect(){ ChanceToAttackModifier = -10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tenta dormir, mas seu passado lhe atormenta.", HGMessageType.NightAction, new HGMessageEffect(){ ChanceToSuicideModifier = 10, ChanceToAttackModifier = -10, HappinessModifier = -10 }),
                    new HGMessage($"**{PlayerTarget1.Name}** consegue dormir a noite inteira.", HGMessageType.NightAction, new HGMessageEffect() { SanityModifier = 20, HappinessModifier = 20 }),
                    new HGMessage($"**{PlayerTarget1.Name}** pensa nos próximos dias da ilha.", HGMessageType.NightAction, new HGMessageEffect() { HappinessModifier = 5 }),
                });
                ItemMessages(false);
            }
        }

        //Attribute Events 
        private void HealthMessages()
        {
            if (Configuration.WorldController.IsDay)
            {
                if (PlayerTarget1.CurrentHealth < 20) //Morrendo
                {
                    messages.AddRange(new HGMessage[] {
                        new HGMessage($"**{PlayerTarget1.Name}** está honrando de dor.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -5, SanityModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** grita desesperadamente pela dor de suas fraturas.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -5, SanityModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** não tem forças para andar por causa da dor alucinante em todo o seu corpo.", HGMessageType.DayAction),
                        new HGMessage($"**{PlayerTarget1.Name}** tenta se curar mas acaba destruindo mais ainda suas feridas, um grito de tortura é ouvido no horizonta.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -5, SanityModifier = -5 }),

                        new HGMessage($"**{PlayerTarget1.Name}** desmaia por causa da dor insuportável que está sentindo.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -5, SanityModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** grita desesperadamente por ajuda.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -10, SanityModifier = -10, ChanceToSuicideModifier = 10  }),
                        new HGMessage($"**{PlayerTarget1.Name}** chora por causa de suas dores alucinógenas.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToSuicideModifier = 5, HappinessModifier = -10, SanityModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** grita por ajuda, mas ninguém aparece.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToSuicideModifier = 5, HappinessModifier = -10, SanityModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** tenta curar suas feridas, mas já é tarde.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToSuicideModifier = 5, HappinessModifier = -10, SanityModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** desenvolveu uma infecção por não tratar suas feridas.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToSuicideModifier = 5, HappinessModifier = -10, SanityModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** não aguenta mais as dores que está sentindo.", HGMessageType.DayAction, new HGMessageEffect() { ChanceToSuicideModifier = 5, HappinessModifier = -10, SanityModifier = -10 }),
                    });
                }

                if (PlayerTarget1.CurrentHealth < 50) //Estavel
                {
                    messages.AddRange(new HGMessage[] {
                        new HGMessage($"**{PlayerTarget1.Name}** tenta curar suas feridas, mas falha.", HGMessageType.DayAction, new HGMessageEffect() { HappinessModifier = -15, SanityModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** tenta curar suas feridas, mas acaba por acidente abrindo todas elas ainda mais.", HGMessageType.DayAction,  new HGMessageEffect() { HappinessModifier = -10, SanityModifier = -15 }),
                        new HGMessage($"**{PlayerTarget1.Name}** cambaleia pela floresta buscando ajuda para se curar.", HGMessageType.DayAction,  new HGMessageEffect() { HappinessModifier = -10, SanityModifier = -20 }),
                        new HGMessage($"**{PlayerTarget1.Name}** sente suas feridas se abrindo.", HGMessageType.DayAction,  new HGMessageEffect() { HappinessModifier = -5, SanityModifier = -8 }),
                    });
                }
            }
            else
            {
                if (PlayerTarget1.CurrentHealth < 20) //Morrendo
                {
                    messages.AddRange(new HGMessage[] {
                        new HGMessage($"**{PlayerTarget1.Name}** é abusado por **{PlayerTarget2.Name}** que se aproveita das dores incapacitantes de **{PlayerTarget1.Name}** para realizar suas ações impuras.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -10}),
                        new HGMessage($"**{PlayerTarget1.Name}** não consegue mais aguentar a dor que está sentindo.", HGMessageType.NightAction, new HGMessageEffect() { SanityModifier = -15, ChanceToSuicideModifier = 10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** tenta cometer suicídio, mas não consegue graças as suas dores alucinantes.", HGMessageType.NightAction, new HGMessageEffect() { SanityModifier = -15, ChanceToSuicideModifier = 10 }),
                    });
                }

                if (PlayerTarget1.CurrentHealth < 50) //Estavel
                {
                    messages.AddRange(new HGMessage[] {
                        new HGMessage($"**{PlayerTarget1.Name}** tenta descançar, mas não consegue graças a dor de suas feridas.", HGMessageType.NightAction, new HGMessageEffect() { SanityModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** vai para um local isolado numa tentativa de ficar seguro.", HGMessageType.NightAction, new HGMessageEffect() { SanityModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** tenta andar pela floresta mas graças as dores não consegue.", HGMessageType.NightAction, new HGMessageEffect() { SanityModifier = -5 }),
                    });
                }
            }
        }
        private void HappinessMessages()
        {
            if (Configuration.WorldController.IsDay)
            {
                if (PlayerTarget1.CurrentHappiness > 50) //feliz
                {
                    messages.AddRange(new HGMessage[] {
                        new HGMessage($"**{PlayerTarget1.Name}** caminha feliz pela Floresta.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = 20 }),
                        new HGMessage($"**{PlayerTarget1.Name}** caminha feliz pela Praia.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = 20 }),
                        new HGMessage($"**{PlayerTarget1.Name}** tem esperança na vitoria.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = 10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** relembra um pouco de seu passado.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = 10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** observa os pequenos animais na natureza.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = 10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** se acalma quando escuta o doce som do mar.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = 10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** se diverte sozinho.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = 10 }),
                    });
                }
                else //triste
                {
                    messages.AddRange(new HGMessage[] {
                        new HGMessage($"**{PlayerTarget1.Name}** anda triste pela floresta.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** tem uma crise existencial.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** tem pensamentos suicidas.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** perdeu as esperanças da vitória.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** não vê mais sentido nas coisas.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** chora em silencio sentado em uma arvore.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** começa a ter uma crise de ansiedade.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** não vê mais esperança nas pessoas.", HGMessageType.DayAction, new HGMessageEffect(){ HappinessModifier = -10 }),
                    });
                }
            }
            else
            {
                if (PlayerTarget1.CurrentHappiness < 50) //triste
                {
                    messages.AddRange(new HGMessage[] {
                        new HGMessage($"**{PlayerTarget1.Name}** tenta se acalmar, mas não consegue.", HGMessageType.NightAction, new HGMessageEffect() { SanityModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** é atormentado pelos seus pensamentos caóticos quando vai dormir.", HGMessageType.NightAction, new HGMessageEffect() { SanityModifier = -10 }),
                        new HGMessage($"**{PlayerTarget1.Name}** chora ao lembrar que pode morrer a quaisquer momentos.", HGMessageType.NightAction, new HGMessageEffect() { SanityModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** não tem segurança de si próprio.", HGMessageType.NightAction, new HGMessageEffect() { HappinessModifier = -10, SanityModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** quer dar um ponto final nisso tudo.", HGMessageType.NightAction, new HGMessageEffect() { HappinessModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** tem pesadelos a noite inteira.", HGMessageType.NightAction, new HGMessageEffect() { HappinessModifier = -5, SanityModifier = -4}),
                        new HGMessage($"**{PlayerTarget1.Name}** está se isolando de todos da ilha.", HGMessageType.NightAction, new HGMessageEffect() { HappinessModifier = -5 }),
                        new HGMessage($"**{PlayerTarget1.Name}** se lembra de todas as coisas ruins que seus parentes já lhe disseram, gritos de tristezas podem ser ouvidos de longe.", HGMessageType.NightAction, new HGMessageEffect() { HappinessModifier = -5, SanityModifier = -6 }),
                    });

                    if (Configuration.PlayersController.DeathPlayers.Count > 0)
                    {
                        messages.AddRange(new HGMessage[] {
                            new HGMessage($"**{PlayerTarget1.Name}** encontra o corpo morto de **{Configuration.PlayersController.GetRandomDeathPlayer().Name}** e sente que um pedaço de sua alma foi destruído.", HGMessageType.NightAction, new HGMessageEffect() { HappinessModifier = -10, SanityModifier = -5 }),
                        });
                    }
                }
            }
        }
        private void SanityMessages()
        {
            if (Configuration.WorldController.IsDay)
            {
                if (PlayerTarget1.CurrentSanity < 50) //Estavel
                {
                    messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** olha ao redor de forma perturbada.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** sente algo tocando seu ombro, mas não há ninguém por perto.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** pensa se viu algo na floresta lhe observando.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** pensa se talvez esteja ficando louco.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** questiona sua sanidade.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    });
                }

                if (PlayerTarget1.CurrentSanity < 20) //Ficando louco
                {
                    messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** começa a gritar desesperadamente.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a ver alucinações.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a ter crises de personalidade.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** sente que consegue falar com os mortos.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"A insanidade de **{PlayerTarget1.Name}** está fazendo ele se sentir um deus.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tem ataques de pânico.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** sente o mundo girando.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** escuta alguém próximo, mas não havia ninguém.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tem ataques de ansiedade.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tenta comer terra.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a discutir com ele mesmo.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tenta arrancar suas mãos ao pensar que são cobras.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** vê algo terrível na floresta.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tenta esquecer de si mesmo.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** brinca de roleta russa.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a ter espasmos involuntários.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a ver parentes falecidos.", HGMessageType.DayAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    });
                }
            }
            else
            {
                if (PlayerTarget1.CurrentSanity < 50) //Estavel
                {
                    messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** começa a tremer descontroladamente.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    });
                }

                if (PlayerTarget1.CurrentSanity < 30) //Ficando louco
                {
                    messages.AddRange(new HGMessage[] {
                    new HGMessage($"**{PlayerTarget1.Name}** começa a rir sozinho.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a rir cada vez mais alto.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a ouvir cochichos e sussurros de todas as direções.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** tem uma crise existencial.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a bater em si mesmo.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** grita muito alto.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** pensa se viu uma alucinação na floresta.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** perfura seu braço com uma pedra e começa a escrever palavras sem sentido.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** não sabe se vai aguentar tudo isso.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a aperta sua perna fazendo pequenas feridas várias vezes.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** quer furar seus olhos.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                    new HGMessage($"**{PlayerTarget1.Name}** começa a sorrir de forma perturbada.", HGMessageType.NightAction, new HGMessageEffect(){ SanityModifier = -5 }),
                });
                }
            }
        }

        //Item Actions
        private void ItemMessages(bool isDay)
        {
            if (!PlayerTarget1.Inventory.HasItems)
                return;

            for (int i = 0; i < PlayerTarget1.Inventory.TotalItemsCount * 2; i++)
            {
                HGWeaponItemBase weaponSelected = null;
                HGDecorativeItemsBase decorativeSelected = null;

                //Preparação das armas
                if (PlayerTarget1.Inventory.TotalWeaponsCount > 0) weaponSelected = PlayerTarget1.Inventory.GetRandomItem<HGWeaponItemBase>();
                if (PlayerTarget1.Inventory.TotalDecorativeCount > 0) decorativeSelected = PlayerTarget1.Inventory.GetRandomItem<HGDecorativeItemsBase>();
                HGItemType itemSelectedType = HGItemType.None;

                //Seleção aleatoria das armas
                if (Random.Next(1, 100) < 50 && weaponSelected != null) itemSelectedType = HGItemType.Weapon;
                else if (decorativeSelected != null) itemSelectedType = HGItemType.Descoration;
                else return;

                if (isDay) //É dia
                {
                    switch (itemSelectedType)
                    {
                        case HGItemType.Weapon:
                            messages.Add(new HGMessage(weaponSelected.GetRandomDayMessage(PlayerTarget1, PlayerTarget2), HGMessageType.DayAction));
                            break;

                        case HGItemType.Descoration:
                            messages.Add(new HGMessage(decorativeSelected.GetRandomDayMessage(PlayerTarget1, PlayerTarget2), HGMessageType.DayAction));
                            break;
                    }
                }
                else //É noite
                {
                    switch (itemSelectedType)
                    {
                        case HGItemType.Weapon:
                            messages.Add(new HGMessage(weaponSelected.GetRandomNightMessage(PlayerTarget1, PlayerTarget2), HGMessageType.NightAction));
                            break;

                        case HGItemType.Descoration:
                            messages.Add(new HGMessage(decorativeSelected.GetRandomNightMessage(PlayerTarget1, PlayerTarget2), HGMessageType.NightAction));
                            break;
                    }
                }
            }
        }
    }
}