using System;
using Items.Core;
using Items.Data;
using Items.Enum;
using Items.Enums;
using StatsSystem;
using UnityEditor;

namespace Items
{
    public class ItemsFactory
    {
        private readonly StatsController _statsController;
        public ItemsFactory(StatsController statsController) => _statsController = statsController;

        public Itemm CreateItem(ItemDescriptor descriptor)
        {
            switch (descriptor.Type)
            {
                case ItemType.Potion:
                    return new Potion(descriptor, _statsController);
                //case ItemType.Misc:
                case ItemType.Shield:
                    return new Equipment(descriptor, _statsController, GetEquipmentType(descriptor));
                default:
                    throw new NullReferenceException($"Item type {descriptor.Type} is not implement yet`");
            }
        }

        private EquipmentType GetEquipmentType(ItemDescriptor descriptor)
        {
            switch (descriptor.Type)
            {
                // case ItemType.Misc:
                //     return EquipmentType.Misc;
                case ItemType.Shield:
                    return EquipmentType.LeftHand;
                case ItemType.Misc:
                case ItemType.Potion:
                default:
                    return EquipmentType.None;
            }
        }
    }
}