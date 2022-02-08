using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGTorchItem : HGWeaponItemBase
    {
        public HGTorchItem()
        {
            Name = "Tocha";
            WordArticle = "a";
            PossessivePronoun = "sua";

            Type = HGItemType.Weapon;
        }

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                "{0} encontra uma tocha.",
                "{0} encontra uma tocha apagada.",
                "{0} faz uma tocha.",
                "{0} cria uma tocha.",
                "{0} acende uma tocha.",
            };
        }

        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                "{0} deixa sua tocha guarda no acampamento.",
                "{0} posiciona suas tochas em locais estratégicos.",
                "{0} coloca tochas ao redor de todo a acampamento.",
            };
        }

        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                "{0} ilumina todo o seu acampamento com tochas.",
                "{0} caça alguns animais com sua tocha.",
                "{0} persegue {1} com sua tocha.",
                "{0} tenta atacar {1} com sua tocha.",
                "{0} coloca tochas na floresta.",
            };
        }

        protected override IEnumerable<string> BuildAttackMessages()
        {
            return new string[]
            {
                "{0} encontra {1} na floresta e com sua tocha na mão ele parte para cima queimando um pouco da pelo de {1} que sai correndo dali.",
                "{0} persegue {1} na floresta e ao encurrala-lo queima um pouco de seu pelo com uma tocha.",
                "{0} arremessa sua tocha em direção a {1} que o queima um pouco.",
            };
        }

        protected override IEnumerable<string> BuildAttackFriendMessages()
        {
            return new string[]
            {
                "{0} com um olhar triste bate em {1} várias vezes com sua tocha fazendo várias queimaduras no corpo dele.",
            };
        }

        protected override IEnumerable<string> BuildMurderMessages()
        {
            return new string[]
            {
                 "{0} andando pela floresta encontra {1} com várias feridas em seu corpo e em um ataque de oportunidade {0} arremessa sua tocha em {1} que queima até a morte."
            };
        }

        protected override IEnumerable<string> BuildMurderFriendMessages()
        {
            return new string[]
            {
                 "{0} andando pela floresta encontra {1} com várias feridas em seu corpo e em um ataque de oportunidade {0} arremessa sua tocha em {1} que queima até a morte."
            };
        }

        protected override IEnumerable<string> BuildSuicideMessages()
        {
            return new string[]
            {
                "{0} quando ia dormir em seu acampamento, acaba deixando sua tocha próximo demais de seu abrigo que começa a queima-lo. {0} não consegue escapar do fogo."
            };
        }
    }
}
