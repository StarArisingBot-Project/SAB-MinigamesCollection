using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGExplosivesItem : HGWeaponItemBase
    {
        public HGExplosivesItem()
        {
            Name = "Explosivos";
            WordArticle = "os";
            PossessivePronoun = "seus";

            Type = HGItemType.Weapon;
        }

        private readonly string ExplosionMurder = "{0} joga suas bombas em direção ao {1} que não tem tempo de reação e acaba sendo explodido.";

        protected override IEnumerable<string> BuildFindingMessages()
        {
            return new string[]
            {
                "{0} encontra alguns explosivos.",
                "{0} recebe explosivos de um patrocinador desconhecido."
            };
        }

        protected override IEnumerable<string> BuildDayMessages()
        {
            return new string[]
            {
                "{0} prepara seus explosivos.",
            };
        }

        protected override IEnumerable<string> BuildNightMessages()
        {
            return new string[]
            {
                "{0} deixa seus explosivos em um local seguro.",
            };
        }

        protected override IEnumerable<string> BuildAttackMessages()
        {
            return new string[]
            {
                "{0} passa correndo proximo ao acampamento de {1} e arremessa suas bombas lá dentro, por sorte {1} consegue sobreviver com apenas algumas queimaduras."
            };
        }

        protected override IEnumerable<string> BuildAttackFriendMessages()
        {
            return new string[]
            {
                "{1} mexendo nos explosivos do {0} acaba explodindo o acampamento e tendo queimaduras graves.",
            };
        }

        protected override IEnumerable<string> BuildMurderMessages()
        {
            return new string[]
            {
                ExplosionMurder,
            };
        }

        protected override IEnumerable<string> BuildMurderFriendMessages()
        {
            return new string[]
            {
                ExplosionMurder
            };
        }

        protected override IEnumerable<string> BuildSuicideMessages()
        {
            return new string[]
            {
                "{0} tentando aprimorar seus explosivos, acaba acidentalmente acionando um que faz uma explosão em cadeia. {0} não consegue resistir aos seus ferimentos.",
            };
        }
    }
}
