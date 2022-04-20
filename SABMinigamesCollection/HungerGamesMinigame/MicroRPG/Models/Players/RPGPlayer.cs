using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarArisingBot.Minigames.MicroRPG
{
    public class RPGPlayer
    {
        public RPGPlayer() { }
        public RPGPlayer(DiscordChannel channel, DiscordMember member)
        {
            ID = member.Id;
            AssignedChannel = channel;
            MemberInfos = member;
        }

        public ulong ID { get; private set; }

        public int Coins { get; private set; }

        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public int MinAttackDamage { get; private set; }
        public int MaxAttackDamage { get; private set; }
        public float CriticalAttackChance { get; private set; }

        public int ShieldForce { get; private set; }
        public int ShieldDurationRounds { get; private set; }
        public int ShieldRoundsToBreak { get; private set; }

        public DiscordChannel AssignedChannel  { get; private set; }
        public DiscordMember MemberInfos { get; private set; }

        public void SetPlayerStatus()
        {
            Coins = 50;

            MaxHealth = 50;
            Health = MaxHealth;

            MinAttackDamage = 1;
            MinAttackDamage = 3;
            CriticalAttackChance = 10;

            ShieldForce = 1;
            ShieldDurationRounds = 3;
            ShieldRoundsToBreak = 0;
        }
    }
}
