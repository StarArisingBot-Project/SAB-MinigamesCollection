using System;
using System.Collections.Generic;
using System.Linq;

namespace StarArisingBot.Minigames.HungerGames
{
    public enum HGItemType
    {
        None,
        Weapon,
        Descoration,
    }

    public abstract class HGItemBase
    {
        public string Name { get; set; }
        public string WordArticle { get; set; }
        public string PossessivePronoun { get; set; }
        public HGItemType Type { get; set; }

        public string[] FindingMessages => BuildFindingMessages().ToArray();
        public string[] DayMessages => BuildDayMessages().ToArray();
        public string[] NightMessages => BuildNightMessages().ToArray();


        private readonly Random random = new Random();

        public string GetRandomFindingMessage(HGPlayer target1, HGPlayer target2)
        {
            string actionSelected = FindingMessages[random.Next(0, FindingMessages.Length)];
            return string.Format(actionSelected, $"**{target1.Name}**", $"**{target2.Name}**");
        }
        public string GetRandomDayMessage(HGPlayer target1, HGPlayer target2)
        {
            string actionSelected = DayMessages[random.Next(0, DayMessages.Length)];
            return string.Format(actionSelected, $"**{target1.Name}**", $"**{target2.Name}**");
        }
        public string GetRandomNightMessage(HGPlayer target1, HGPlayer target2)
        {
            string actionSelected = NightMessages[random.Next(0, NightMessages.Length)];
            return string.Format(actionSelected, $"**{target1.Name}**", $"**{target2.Name}**");
        }

        protected abstract IEnumerable<string> BuildFindingMessages();
        protected abstract IEnumerable<string> BuildDayMessages();
        protected abstract IEnumerable<string> BuildNightMessages();
    }
}
