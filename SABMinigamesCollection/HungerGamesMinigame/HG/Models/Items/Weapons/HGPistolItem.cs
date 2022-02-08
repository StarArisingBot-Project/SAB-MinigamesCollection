using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGPistolItem : HGWeaponItemBase
    {
        public HGPistolItem()
        {
            Name = "Pistola";
            WordArticle = "a";
            PossessivePronoun = "sua";

            Type = HGItemType.Weapon;
        }

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                "{0} encontra uma pistola.",
                "{0} recebe uma pistola de um patrocinador desconhecido.",
            };
        }

        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                "{0} passa a tarde treinando tiro ao alvo.",
            };
        }

        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                "{0} tenta caçar alguns animais com sua pistola.",
            };
        }

        protected override IEnumerable<string> BuildAttackMessages()
        {
            return new string[]
            {
                "{0} com sua pistola atira contra {1} que recebe um tiro de raspão.",
            };
        }

        protected override IEnumerable<string> BuildAttackFriendMessages()
        {
            return new string[]
            {
                "{0} sabendo que para vencer teria que batalhar contra seus amigos, atira em {1} que estava andando pela floresta, o tiro passa de raspão.",
            };
        }

        protected override IEnumerable<string> BuildMurderMessages()
        {
            return new string[]
            {
                "{0} chuta violentamente a perna de {1} quebrando-a, depois finaliza atirando com sua pistola na cabeça dele.",
            };
        }

        protected override IEnumerable<string> BuildMurderFriendMessages()
        {
            return new string[]
            {
                "{0} sabendo que para vencer teria que matar seus amigos, atira contra {1} que estava dormindo, sua morte é instantânea.",
            };
        }

        protected override IEnumerable<string> BuildSuicideMessages()
        {
            return new string[]
            {
                "{0} não aguenta a pressão da ilha e dá um tiro em sua própria cabeça.",
            };
        }
    }
}
