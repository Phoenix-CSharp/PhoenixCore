using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using UtfUnknown.Core.Models.SingleByte.Thai;

namespace WaMCore.Core.Items.Range{
    [Autoload(false)]
    public class CustomAmmoGunItem : GeneralItem, RangeItem{
        public sealed override DamageClass damageType { get; } = DamageClass.Ranged;
        public int projectileID { get; }
        public int ammoID { get; }
        public float shootSpeed { get; }
        public SoundStyle sound { get; }
        public int use_animationTime { get; }
        public bool isPistol { get; }
        public CustomAmmoGunItem(int projectileID, int ammoID, int use_animationTime, float shootSpeed, bool isPistol, SoundStyle sound){
            this.projectileID = projectileID;
            this.ammoID = ammoID;
            this.use_animationTime = use_animationTime;
            this.shootSpeed = shootSpeed;
            this.isPistol = isPistol;
            this.sound = sound;
        }
        
        public override void SetDefaults()
        {
            Item.DefaultToRangedWeapon(projectileID, ammoID, use_animationTime, shootSpeed, !isPistol);
            Item.UseSound = sound;
        }
    }
}