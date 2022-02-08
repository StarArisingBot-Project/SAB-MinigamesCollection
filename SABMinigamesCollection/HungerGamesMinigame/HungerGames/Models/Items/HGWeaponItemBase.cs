using System;
using System.Collections.Generic;
using System.Linq;

namespace StarArisingBot.Minigames.HungerGames
{
    public abstract class HGWeaponItemBase : HGItemBase
    {
        public string[] SuicideMessages => BuildSuicideMessages().ToArray();

        public string[] AttackMessages => BuildAttackMessages().ToArray();
        public string[] AttackFriendMessages => BuildAttackFriendMessages().ToArray();

        public string[] MurderMessages => BuildMurderMessages().ToArray();
        public string[] MurderFriendMessages => BuildMurderFriendMessages().ToArray();


        private readonly Random random = new Random();

        public string GetRandomSuicideMessage(HGPlayer target1, HGPlayer target2)
        {
            string actionSelected = SuicideMessages[random.Next(0, SuicideMessages.Length)];
            return string.Format(actionSelected, $"**{target1.Name}**", $"**{target2.Name}**");
        }
        public string GetRandomAttackMessage(HGPlayer target1, HGPlayer target2)
        {
            string actionSelected = AttackMessages[random.Next(0, AttackMessages.Length)];
            return string.Format(actionSelected, $"**{target1.Name}**", $"**{target2.Name}**");
        }
        public string GetRandomAttackFriendMessage(HGPlayer target1, HGPlayer target2)
        {
            string actionSelected = AttackFriendMessages[random.Next(0, AttackFriendMessages.Length)];
            return string.Format(actionSelected, $"**{target1.Name}**", $"**{target2.Name}**");
        }
        public string GetRandomMurderMessage(HGPlayer target1, HGPlayer target2)
        {
            string actionSelected = MurderMessages[random.Next(0, MurderMessages.Length)];
            return string.Format(actionSelected, $"**{target1.Name}**", $"**{target2.Name}**");
        }
        public string GetRandomMurderFriendMessage(HGPlayer target1, HGPlayer target2)
        {
            string actionSelected = MurderFriendMessages[random.Next(0, MurderFriendMessages.Length)];
            return string.Format(actionSelected, $"**{target1.Name}**", $"**{target2.Name}**");
        }

        protected abstract IEnumerable<string> BuildSuicideMessages();

        protected abstract IEnumerable<string> BuildAttackMessages();
        protected abstract IEnumerable<string> BuildAttackFriendMessages();

        protected abstract IEnumerable<string> BuildMurderMessages();
        protected abstract IEnumerable<string> BuildMurderFriendMessages();
    }
}
