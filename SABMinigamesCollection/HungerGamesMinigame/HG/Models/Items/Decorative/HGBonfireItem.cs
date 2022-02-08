using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    internal class HGBonfireItem : HGDecorativeItemsBase
    {
        public HGBonfireItem()
        {
            Name = "Fogueira";
            WordArticle = "a";
            PossessivePronoun = "sua";

            Type = HGItemType.Descoration;
        }

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                "{0} faz uma fogueira.",
                "{0} encontra uma fogueira.",
            };
        }

        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                "{0} se queima em sua fogueira.",
                "{0} usa sua fogueira para preparar comida.",
                "{0} usa sua fogueira para preparar água.",
            };
        }

        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                "A fogueira de {0} apaga graças aos fortes ventos da noite.",
                "{0} tenta se aquecer na fogueira.",
                "{0} dorme acomodado próximo a fogueira.",
                "{0} fica acordado em posição fetal em frente sua fogueira.",
            };
        }
    }
}
