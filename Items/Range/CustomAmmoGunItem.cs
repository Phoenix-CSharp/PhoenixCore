using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Items.Range{
    public class CustomAmmoGunItem : RangeItem{
        public sealed override DamageClass damageType { get; } = DamageClass.Ranged;
        public virtual int ammoID { get; set; }
        public virtual float shootSpeed { get; set; }
        public virtual SoundStyle sound { get; set; }
        public override void SetDefaults()
        {
            Item.autoReuse = true;
            Item.DamageType = damageType;
            Item.noMelee = true;
            Item.shootSpeed = shootSpeed;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = sound;
            Item.shoot = projectileID;
            Item.useAmmo = ammoID;
        }
    }
}