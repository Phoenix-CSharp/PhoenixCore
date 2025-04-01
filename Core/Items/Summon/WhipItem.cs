using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Summon{
    public class WhipItem : Base_SummonItem{
        public sealed override DamageClass damageType { get; } = DamageClass.SummonMeleeSpeed; 
        public override void SetDefaults()
        {
            Item.DefaultToWhip(whipProjectileID, damage, knockback, shotSpeed);
        }
        public sealed override bool MeleePrefix()
        {
            return true;
        }
    }
}