using Items.Data;
using Items.Enums;
using StatsSystem;

namespace Items.Core
{
    public class Equipment : Itemm
    {
        private readonly StatsController _statsController;
        private readonly StatChangingItemDescriptor _itemDescriptor ;

        private bool _equipped;

        public override int Amount => -1;

        public EquipmentType EquipmentType { get; }

        public Equipment(ItemDescriptor descriptor, StatsController statsController, EquipmentType equipmentType) : base(descriptor)
        {
            _itemDescriptor = descriptor as StatChangingItemDescriptor;
            _statsController = statsController;
            EquipmentType = equipmentType;
        }


        public override void Use()
        {
            if (_equipped)
                UnEquip();
            else Equip();
        }

        private void Equip()
        {
            _equipped = true;
            foreach (var stat in _itemDescriptor.Stats)
            {
                _statsController.ProcessModificator(stat);
            }
        }

        private void UnEquip()
        {
            _equipped = false;
            foreach (var stat in _itemDescriptor.Stats)
            {
                _statsController.ProcessModificator(stat.GetReverseModificator());
            }
        }
    }
}