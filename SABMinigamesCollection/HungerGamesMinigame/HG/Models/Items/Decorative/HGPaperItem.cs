using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    internal class HGPaperItem : HGDecorativeItemsBase
    {
        public HGPaperItem()
        {
            Name = "Papel";
            WordArticle = "o";
            PossessivePronoun = "seu";

            Type = HGItemType.Descoration;
        }

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                "{0} andando pela floresta encontra um papel amassado",
                "{0} pisa em um pape amassado.",
                "{0} encontra um papel."
            };
        }

        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                "{0} faz um pequeno desenho em seu papel.",
                "{0} faz um origame com seu papel.",
                "{0} escreve pequenas frases em seu papel.",
                "{0} escreve seus sonhos no papel."
            };
        }

        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                "{0} guarda todos os seus itens e ao ir dormir nota que caiu um papel de seu bolso.",
                "{0} faz uma carta para sua familia.",
                "{0} anota seus planos de vida no papel amassado.",
                "{0} anota o seu maior pesadelo no papel.",
                @"{0} corta um pouco de sua pele e escreve com seu sangue ""{1}"" no papel."
            };
        }
    }
}
