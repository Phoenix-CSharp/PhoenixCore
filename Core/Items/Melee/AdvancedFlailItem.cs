using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Melee{
    public class AdvancedFlail : MeleeItem{
        public sealed override DamageClass damageType { get; } = DamageClass.MeleeNoSpeed;
        public virtual int projectileID { get; set; }
        public virtual SoundStyle sound { get; set; }
        public virtual float shootSpeed { get; set; }
        public virtual float damageMultiplier { get; set; }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ToolTipDamageMultiplier[Type] = damageMultiplier;
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = true;
            Item.shoot = projectileID;
            Item.shootSpeed = shootSpeed;
            Item.UseSound = sound;
            Item.DamageType = damageType;
            Item.channel = true;
            Item.noMelee = true;
        }

    }
}