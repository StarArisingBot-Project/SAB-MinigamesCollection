using System;
using System.Collections.Generic;
using System.Linq;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGInventory
    {
        public List<HGWeaponItemBase> WeaponItems => weaponItems;
        public List<HGDecorativeItemsBase> DecorativeItems => decorativeItems;

        private readonly List<HGWeaponItemBase> weaponItems = new List<HGWeaponItemBase>();
        private readonly List<HGDecorativeItemsBase> decorativeItems = new List<HGDecorativeItemsBase>();

        public bool HasItems
        {
            get
            {
                if (WeaponItems.Count > 0 || DecorativeItems.Count > 0)
                    return true;

                return false;
            }
        }
        public int TotalItemsCount => weaponItems.Count + decorativeItems.Count;
        public int TotalWeaponsCount => weaponItems.Count;
        public int TotalDecorativeCount => decorativeItems.Count;

        private readonly Random random = new Random();

        public T GetRandomItem<T>()
        {
            List<HGWeaponItemBase> waeponsFinding = weaponItems.Where(x => x.Type == HGItemType.Weapon).ToList();
            List<HGDecorativeItemsBase> decorationsFinding = decorativeItems.Where(x => x.Type == HGItemType.Descoration).ToList();

            if (typeof(T) == typeof(HGWeaponItemBase))
            {
                return (T)(object)waeponsFinding[random.Next(0, waeponsFinding.Count - 1)];
            }
            else if (typeof(T) == typeof(HGDecorativeItemsBase))
            {
                return (T)(object)decorationsFinding[random.Next(0, decorationsFinding.Count - 1)];
            }
            else
            {
                return (T)(object)waeponsFinding[random.Next(0, waeponsFinding.Count - 1)];
            }
        }

        public void AddItem(HGWeaponItemBase item)
        {
            weaponItems.Add(item);
        }
        public void AddItem(HGDecorativeItemsBase item)
        {
            decorativeItems.Add(item);
        }

        public void AddItems(IEnumerable<HGWeaponItemBase> items)
        {
            weaponItems.AddRange(items);
        }
        public void AddItems(IEnumerable<HGDecorativeItemsBase> items)
        {
            decorativeItems.AddRange(items);
        }

        public void RemoveItem(HGWeaponItemBase item)
        {
            weaponItems.Remove(item);
        }
        public void RemoveItem(HGDecorativeItemsBase item)
        {
            decorativeItems.Remove(item);
        }
    }
}
