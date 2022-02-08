using System;
using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    internal class HGFruitItem : HGDecorativeItemsBase
    {
        private class HGFruitInfo
        {
            public string Name { get; set; }
            public string WordArticle { get; set; }
            public string PossessivePronoun { get; set; }
            public string IndefiniteArticle { get; set; }
        }

        private readonly HGFruitInfo FruitSelected;
        public HGFruitItem()
        {
            HGFruitInfo[] fruits = {
                new HGFruitInfo()
                {
                    Name = "Banana",
                    WordArticle = "a",
                    PossessivePronoun = "sua",
                    IndefiniteArticle = "uma",
                },

                new HGFruitInfo()
                {
                    Name = "Maçã",
                    WordArticle = "a",
                    PossessivePronoun = "sua",
                    IndefiniteArticle = "uma",
                },

                new HGFruitInfo()
                {
                    Name = "Abacaxi",
                    WordArticle = "o",
                    PossessivePronoun = "seu",
                    IndefiniteArticle = "um",
                },

                new HGFruitInfo()
                {
                    Name = "Goiaba",
                    WordArticle = "a",
                    PossessivePronoun = "sua",
                    IndefiniteArticle = "uma",
                },

                new HGFruitInfo()
                {
                    Name = "Limão",
                    WordArticle = "o",
                    PossessivePronoun = "seu",
                    IndefiniteArticle = "um",
                },

                new HGFruitInfo()
                {
                    Name = "Laranja",
                    WordArticle = "a",
                    PossessivePronoun = "sua",
                    IndefiniteArticle = "uma",
                },

                new HGFruitInfo()
                {
                    Name = "Mexerica",
                    WordArticle = "a",
                    PossessivePronoun = "sua",
                    IndefiniteArticle = "uma",
                }
            };

            FruitSelected = fruits[new Random().Next(0, fruits.Length)];

            Name = FruitSelected.Name;
            WordArticle = FruitSelected.WordArticle;
            PossessivePronoun = FruitSelected.PossessivePronoun;

            Type = HGItemType.Descoration;
        }

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                $"{{0}} apanha {FruitSelected.IndefiniteArticle} {FruitSelected.Name} das mãos de {{1}}.",
                $"{{0}} rouba {FruitSelected.IndefiniteArticle} {FruitSelected.Name} das mãos de {{1}}.",
                $"{{0}} pega {FruitSelected.IndefiniteArticle} {FruitSelected.Name} das mãos de {{1}}.",
                $"{{0}} encontra {FruitSelected.IndefiniteArticle} {FruitSelected.Name} na floresta."
            };
        }
        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                $"{{0}} come {FruitSelected.IndefiniteArticle} {FruitSelected.Name}.",
                $"{{0}} prepara {FruitSelected.PossessivePronoun} {FruitSelected.Name} para comer.",
                $"{{0}} deixa {FruitSelected.PossessivePronoun} {FruitSelected.Name} no acampamento.",
                $"{{0}} usa {FruitSelected.PossessivePronoun} {FruitSelected.Name} para tentar caçar.",
            };
        }
        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                  $"{{0}} antes de dormir, come {FruitSelected.PossessivePronoun} {FruitSelected.Name}.",
                  $"{{0}} come {FruitSelected.IndefiniteArticle} {FruitSelected.Name}.",
                  "{0} suas frutas em um local seguro.",
            };
        }
    }
}
