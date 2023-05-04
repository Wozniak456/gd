using Items.Data;

namespace Items.Core
{
    public abstract class Itemm
    {
        public ItemDescriptor Descriptor { get; }
        public abstract int Amount { get; }
        protected Itemm(ItemDescriptor descriptor) => Descriptor = descriptor;
        public abstract void Use();
    }
}