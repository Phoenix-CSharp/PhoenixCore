using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.ModLoader;

namespace PhoenixCore.Items.Range
{
    [Autoload(false)]
    public class MinigunItem : GeneralItem, IRangeItem
    {
        public int projectileID { get; }
        public float shootSpeed { get; }
        public SoundStyle sound { get; }
        public int? ammoID { get; }
        public int use_animationTime { get; }
        public float? chanceNotConsumeAmmo { get; }
        public int spreedAngle { get; }
        public int minAmmoCount { get; }
        public bool isSingleShot { get; }
        public MinigunItem(int projectileID, float shootSpeed, SoundStyle sound, int ammoID, int use_animationTime, int spreedAngle, int minAmmoCount, bool isSingleShot, float? chanceNotConsumeAmmo = null)
        {
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.sound = sound;
            this.ammoID = ammoID;
            this.use_animationTime = use_animationTime;
            this.chanceNotConsumeAmmo = chanceNotConsumeAmmo;
            this.spreedAngle = spreedAngle;
            this.minAmmoCount = minAmmoCount;
            this.isSingleShot = isSingleShot;
        }
        public override void SetDefaults()
        {
            Item.DefaultToRangedWeapon(projectileID, (int)ammoID, use_animationTime, shootSpeed, !isSingleShot);
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= (chanceNotConsumeAmmo == null ? 0f : (float)chanceNotConsumeAmmo);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(spreedAngle));
        }
        public override bool NeedsAmmo(Player player)
        {
            return player.CountItem((int)ammoID, minAmmoCount) < minAmmoCount;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, -2f);
        }
    }
}