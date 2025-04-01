using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items{
    [Autoload(false)]
    public class MagicItem : ModItem{
        public virtual int mana { get; }
        public virtual DamageClass damageType { get; }
        public sealed override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }
        public sealed override bool MagicPrefix()
        {
            return true;
        }
    }
    [Autoload(false)]
    public class MeleeItem : ModItem{
        public virtual DamageClass damageType { get; }
        public sealed override bool MeleePrefix()
        {
            return true;
        }
    }
    [Autoload(false)]
    public class SummonItem : ModItem{
        public virtual int mana { get; }
        public virtual float minionSlotsRequired { get; }
        public virtual Projectile minion { get; }
        public virtual ModBuff minionBuff { get; } 
        public virtual DamageClass damageType { get; }
        public sealed override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
            ItemID.Sets.StaffMinionSlotsRequired[Item.type] = minionSlotsRequired;
        }
    }
    [Autoload(false)]
    public class RangeItem : ModItem{
        public virtual int projectileID { get; }
        public virtual DamageClass damageType { get; }
    }
    [Autoload(false)]
    public class CustomDamageItem : ModItem{
        public virtual DamageClass customDamageType { get;}
    }
}