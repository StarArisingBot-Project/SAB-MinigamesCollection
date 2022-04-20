using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGAxeItem : HGWeaponItemBase
    {
        public HGAxeItem()
        {
            Name = "Machado";
            WordArticle = "o";
            PossessivePronoun = "seu";

            Type = HGItemType.Weapon;
        }

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                "{0} fez um machado.",
                "{0} encontrou um machado enquanto explorava a floresta.",
                "{0} encontra um machado cravado em uma arvore.",
                "{0} enquanto explorava ao redor de seu acampamento, encontrou um machado entre as folhas e plantas.",
            };
        }

        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                "{0} derruba algumas arvores com seu machado.",
                "{0} persegue alguns animais na floresta com seu machado.",
                "{0} tenta caçar com seu machado."
            };
        }

        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                "{0} esconde seu machado em um local seguro.",
                "{0} deixa seu machado ao seu lado enquanto vai dormir.",
                "{0} fica com seu machado em suas mãos vendo se há alguém por perto."
            };
        }

        protected override IEnumerable<string> BuildAttackMessages()
        {
            return new string[]
            {
                "{0} vê {1} ao longe e começa a correr em direção a ele, ao se aproximar {0} tenta corta-lo com seu machado, mas acaba falhando e dando apenas um pequeno corte em {1} que saí correndo dali.",
                "{0} encontra {1} no meio da floresta, em um ataque ágil, {0} tenta bater a lâmina de seu machado no {1} que desvia mas acaba tendo uma parte de seu rosto e braço cortados."
            };
        }

        protected override IEnumerable<string> BuildAttackFriendMessages()
        {
            return new string[]
            {
                "{0} sabendo que para vencer teria que matar seus amigos, parte para cima de {1} que tenta se defender mas acaba falhando levando um ataque em cheio do machado de {0} na perna.",
                "{0} caminha em direção a sua barraca onde {1} está e em um ataque surpresa, {0} acaba acertando seu machado na perna de {1}, que por um milagre, consegue fugir dali."
            };
        }

        protected override IEnumerable<string> BuildMurderMessages()
        {
            return new string[]
            {
                "Sem piedade, {0} bate a lâmina de seu machado incansavelmente no corpo de {1} fazendo várias feridas Exorbitantes até mata-lo(a) completamente.",
                "{0} leva {1} em um local longe de todos os tributos da ilha, lá {0} pega seu machado e começa a arrancar cada um dos braços e pernas do {1} que entra em uma dor alucinógena, depois finaliza perfurando sua cabeça com a lâmina do machado.",
                "{0} encontra {1} na floresta e em um movimento rápido bate com toda a força na cabeça de {1} com seu machado a partindo ao meio.",
            };
        }

        protected override IEnumerable<string> BuildMurderFriendMessages()
        {
            return new string[]
            {
                "{0} depressivo por saber que teria que matar um amigo para vencer, combina com {1} uma última batalha, {1} aceita e a batalha começa. \n{0} parte para cima de seu amigo e em um movimento rápido, consegue mata-lo em um golpe. {1} caí em seus braços e usando suas últimas forças, diz que acredita que {0} vencerá.",
                "{1} sedento pela vitória, rouba o machado de seu amigo e entra na cabana que eles construíram, {1} encontra {0} preparando algumas armas, em uma tentativa de assassinar o seu amigo {1} tenta bater seu machado com toda a força no {0} que desvia e pega o machado rapidamente. Ao ver que seu melhor amigo lhe traiu, {0} corta o pescoço de {1} o matando instantaneamente.",
            };
        }

        protected override IEnumerable<string> BuildSuicideMessages()
        {
            return new string[]
            {
               "{0} sem mais esperanças, corta seu próprio pescoço com a lâmina de seu machado. Sua morte chega eventualmente.",
               "{0} sem mais esperanças, corta seu próprio pulso com a lâmina de seu machado. Sua morte chega eventualmente.",
               "{1} entra na cabana de {0} e rouba seu machado, {0} o persegue pela floresta mas acaba o perdendo vista, de repente, um ataque rápido é executo e {0} tem seu pescoço cortado pelo seu próprio machado."
            };
        }
    }
}
