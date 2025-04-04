using Terraria;
using Terraria.Audio;

namespace PhoenixCore.Items.Range
{
    public class CustomAmmoGunItem : GeneralItem, IRangeItem
    {
        public int projectileID { get; }
        public int? ammoID { get; }
        public float shootSpeed { get; }
        public SoundStyle sound { get; }
        public int use_animationTime { get; }
        public bool isSingleShot { get; }
        public float? chanceNotConsumeAmmo { get; }
        public CustomAmmoGunItem(int projectileID, int ammoID, int use_animationTime, float shootSpeed, bool isSingleShot, SoundStyle sound, float? chanceNotConsumeAmmo = null) : base()
        {
            this.projectileID = projectileID;
            this.ammoID = ammoID;
            this.use_animationTime = use_animationTime;
            this.shootSpeed = shootSpeed;
            this.isSingleShot = isSingleShot;
            this.sound = sound;
            this.chanceNotConsumeAmmo = chanceNotConsumeAmmo;
        }
        public override void SetDefaults()
        {
            Item.DefaultToRangedWeapon(projectileID, (int)ammoID, use_animationTime, shootSpeed, !isSingleShot);
            Item.UseSound = sound;
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= (chanceNotConsumeAmmo == null ? 1.1f : (float)chanceNotConsumeAmmo);
        }
    }
}