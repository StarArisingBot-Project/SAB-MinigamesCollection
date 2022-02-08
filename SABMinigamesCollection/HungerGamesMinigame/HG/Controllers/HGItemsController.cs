using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGItemsController
    {
        public List<HGWeaponItemBase> TotalWeaponItems { get { return totalWaponsItems; } }
        public List<HGDecorativeItemsBase> TotalDecorativeItems { get { return totalDecorativeItems; } }

        private readonly List<HGWeaponItemBase> totalWaponsItems;
        private readonly List<HGDecorativeItemsBase> totalDecorativeItems;

        private readonly HGMinigame hgMinigame;
        private readonly CommandContext context;

        private readonly Random random;

        public HGItemsController(HGMinigame hgMinigame, CommandContext context)
        {
            this.hgMinigame = hgMinigame;
            this.context = context;

            random = new Random();

            totalWaponsItems = new List<HGWeaponItemBase>(BuildAllWeapons());
            totalDecorativeItems = new List<HGDecorativeItemsBase>(BuildAllDecoratives());
        }

        private IEnumerable<HGWeaponItemBase> BuildAllWeapons()
        {
            List<HGWeaponItemBase> items = new List<HGWeaponItemBase>
            {
                //Armas
                new HGSworldItem(),
                new HGBowItem(),
                new HGExplosivesItem(),
                new HGKnifeItem(),
                new HGPistolItem(),
                new HGTorchItem()
            };

            return items;
        }
        private IEnumerable<HGDecorativeItemsBase> BuildAllDecoratives()
        {
            List<HGDecorativeItemsBase> items = new List<HGDecorativeItemsBase>
            {

                //Armas
                new HGFruitItem(),
                new HGBonfireItem(),
                new HGPaperItem()
            };

            return items;
        }

        public T GetRandomItem<T>()
        {
            HGWeaponItemBase weaponSelected = totalWaponsItems[random.Next(0, totalWaponsItems.Count - 1)];
            HGDecorativeItemsBase decorativeSelected = totalDecorativeItems[random.Next(0, totalDecorativeItems.Count - 1)];

            if (typeof(T) == typeof(HGWeaponItemBase))
            {
                return (T)(object)weaponSelected;
            }
            else if (typeof(T) == typeof(HGDecorativeItemsBase))
            {
                return (T)(object)decorativeSelected;
            }
            else
            {
                return (T)(object)weaponSelected;
            }
        }
    }
}
