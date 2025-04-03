using Terraria;
using Terraria.Audio;

namespace WaMCore.Core.Items.Range
{
    public class CustomAmmoGunItem : GeneralItem, IRangeItem
    {
        public int projectileID { get; }
        public int? ammoID { get; }
        public float shootSpeed { get; }
        public SoundStyle sound { get; }
        public int use_animationTime { get; }
        public bool isSingleShot { get; }
        public CustomAmmoGunItem(int projectileID, int ammoID, int use_animationTime, float shootSpeed, bool isSingleShot, SoundStyle sound) : base()
        {
            this.projectileID = projectileID;
            this.ammoID = ammoID;
            this.use_animationTime = use_animationTime;
            this.shootSpeed = shootSpeed;
            this.isSingleShot = isSingleShot;
            this.sound = sound;
        }

        public override void SetDefaults()
        {
            Item.DefaultToRangedWeapon(projectileID, (int)ammoID, use_animationTime, shootSpeed, !isSingleShot);
            Item.UseSound = sound;
        }
    }
}