using System;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGMessageEffect
    {
        public HGMessageEffect() { }
        public HGPlayer ApplyEffect(HGPlayer playersAffected)
        {
            # region Aplicar Alterações
            playersAffected.CurrentHealth += HealthModifier;
            playersAffected.CurrentSanity += SanityModifier;
            playersAffected.CurrentHappiness += HappinessModifier;
            playersAffected.ExtraForce += ExtraForceModifier;

            playersAffected.ChanceToFindingItem += ChanceToFindingItemModifier;
            playersAffected.ChanceToAttack += ChanceToAttackModifier;
            playersAffected.ChanceToMakeFriend += ChanceToMakeFriendModifier;
            playersAffected.ChanceToSuicide += ChanceToSuicideModifier;

            playersAffected.ChanceToNormalAction += -5;
            #endregion
            # region Bloquear os Limites
            playersAffected.CurrentHealth = Math.Clamp(playersAffected.CurrentHealth, 1, 100);
            playersAffected.CurrentSanity = Math.Clamp(playersAffected.CurrentSanity, 1, 100);
            playersAffected.CurrentHappiness = Math.Clamp(playersAffected.CurrentHappiness, 1, 100);
            playersAffected.ExtraForce = Math.Clamp(playersAffected.ExtraForce, 1, 100);

            playersAffected.ChanceToFindingItem = Math.Clamp(playersAffected.ChanceToFindingItem, 1, 100);
            playersAffected.ChanceToAttack = Math.Clamp(playersAffected.ChanceToAttack, 1, 100);
            playersAffected.ChanceToMakeFriend = Math.Clamp(playersAffected.ChanceToMakeFriend, 1, 100);
            playersAffected.ChanceToSuicide = Math.Clamp(playersAffected.ChanceToSuicide, 1, 100);

            playersAffected.ChanceToNormalAction = Math.Clamp(playersAffected.CurrentHealth, 1, 100);
            #endregion

            return playersAffected;
        }

        public int HealthModifier { get; set; }
        public int SanityModifier { get; set; }
        public int HappinessModifier { get; set; }
        public int ExtraForceModifier { get; set; }

        public int ChanceToFindingItemModifier { get; set; }
        public int ChanceToAttackModifier { get; set; }
        public int ChanceToMakeFriendModifier { get; set; }
        public int ChanceToSuicideModifier { get; set; }
    }
}