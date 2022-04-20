using System;

namespace StarArisingBot.Minigames.HungerGames
{
    public class FindObjectsMesagePack : HGBaseMessagePack
    {
        private HGWeaponItemBase WeaponFinding;
        private HGDecorativeItemsBase DecorativeFinding;

        protected override void BuildPack()
        {
            WeaponFinding = Configuration.ItemsController.GetRandomItem<HGWeaponItemBase>();
            DecorativeFinding = Configuration.ItemsController.GetRandomItem<HGDecorativeItemsBase>();

            switch (Random.Next(1, 100))
            {
                case < 50:
                    FindingWeaponItem();
                    PlayerTarget1.Inventory.AddItem(WeaponFinding);
                    break;

                case >= 50:
                    FindingDecorative();
                    PlayerTarget1.Inventory.AddItem(DecorativeFinding);
                    break;
            }
        }

        private void FindingWeaponItem()
        {
            if (Configuration.WorldController.IsDay)
            {
                messages.Add(new HGMessage(WeaponFinding.GetRandomFindingMessage(PlayerTarget1, PlayerTarget2), HGMessageType.DayAction, new HGMessageEffect() { ChanceToAttackModifier = 20, ChanceToSuicideModifier = -15, HappinessModifier = 15, SanityModifier = 10 }));
            }
            else
            {
                messages.Add(new HGMessage(WeaponFinding.GetRandomFindingMessage(PlayerTarget1, PlayerTarget2), HGMessageType.NightAction, new HGMessageEffect() { ChanceToAttackModifier = 20, ChanceToSuicideModifier = -15, HappinessModifier = 15, SanityModifier = 10 }));
            }
        }

        private void FindingDecorative()
        {
            if (Configuration.WorldController.IsDay)
            {
                messages.Add(new HGMessage(DecorativeFinding.GetRandomFindingMessage(PlayerTarget1, PlayerTarget2), HGMessageType.DayAction, new HGMessageEffect() { ChanceToAttackModifier = 20, ChanceToSuicideModifier = -15, HappinessModifier = 15, SanityModifier = 10 }));
            }
            else
            {
                messages.Add(new HGMessage(DecorativeFinding.GetRandomFindingMessage(PlayerTarget1, PlayerTarget2), HGMessageType.NightAction, new HGMessageEffect() { ChanceToAttackModifier = 20, ChanceToSuicideModifier = -15, HappinessModifier = 15, SanityModifier = 10 }));
            }
        }
    }
}
