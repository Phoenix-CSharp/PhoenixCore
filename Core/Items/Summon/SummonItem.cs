using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Summon{
    public class SummonItem : Base_SummonItem{
        public override DamageClass damageType { get; } = DamageClass.Summon;
        public sealed override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
            ItemID.Sets.StaffMinionSlotsRequired[Item.type] = minionSlotsRequired;
        }
    }
}