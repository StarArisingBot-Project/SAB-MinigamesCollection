using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGKnifeItem : HGWeaponItemBase
    {
        public HGKnifeItem()
        {
            Name = "Faca";
            WordArticle = "a";
            PossessivePronoun = "sua";

            Type = HGItemType.Weapon;
        }

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                "{0} encontra uma faca.",
                "{0} faz uma faca.",
                "{0} rouba uma faca."
            };
        }

        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                "{0} passa a tarde treinando com sua faca.",
            };
        }

        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                "{0} tenta caçar animais com sua faca.",
            };
        }

        protected override IEnumerable<string> BuildAttackMessages()
        {
            return new string[]
            {
                "{0} encontra {1} na floresta e rapidamente parte para cima dele com sua faca, uma batalha começa e {0} consegue fazer um pequeno corte em {1} com sua faca, mas {1} acaba fugindo dali."
            };
        }

        protected override IEnumerable<string> BuildAttackFriendMessages()
        {
            return new string[]
            {
                "{0} parte para cima de {1} com sua faca, {1} não percebe a presença de {0} e acaba levando uma facada no estomago.",
            };
        }

        protected override IEnumerable<string> BuildMurderMessages()
        {
            return new string[]
            {
                "{0} começa a partir o corpo de {1} vivo em vários pedaços com sua faca, gritos de dor são ouvidos na distância.",
                "{0} entra em uma casa abandonada onde lá dentro estava {1}. {0} o ataca impetuosamente por trás desferindo várias facadas.",
                "{1} encontra {0} em seu caminho. {0} propõem uma aliança de paz para {1} que aceita. Depois de algumas horas {0} quebra a aliança matando a facadas {1}",
            };
        }

        protected override IEnumerable<string> BuildMurderFriendMessages()
        {
            return new string[]
            {
                "{0} arremessa uma faca aleatoriamente na floresta. A faca acerta a cabeça do(a) {1} que cai morto no chão.",
            };
        }

        protected override IEnumerable<string> BuildSuicideMessages()
        {
            return new string[]
            {
                "{0} corta seu próprio pulso com sua faca."
            };
        }
    }
}
