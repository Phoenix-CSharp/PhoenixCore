using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items{
    [Autoload(false)]
    public class Base_MagicItem : ModItem{
        public virtual int mana { get; }
        public virtual DamageClass damageType { get; }
        public virtual int projectileID { get; }
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
    public class Base_SummonItem : ModItem{
        public virtual int whipProjectileID { get; }
        public virtual int damage { get; }
        public virtual float knockback { get; }
        public virtual float shotSpeed { get; }
        public virtual int mana { get; }
        public virtual float minionSlotsRequired { get; }
        public virtual int minion { get; }
        public virtual int minionBuff { get; }
        public virtual DamageClass damageType { get; }
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