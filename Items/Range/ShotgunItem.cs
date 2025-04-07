
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhoenixCore.Items.Range
{
    [Autoload(false)]
    public class ShotgunItem : GeneralItem, IRangeItem
    {
        public int projectileID { get; }
        public float shootSpeed { get; }
        public SoundStyle sound { get; }
        public int? ammoID { get; }
        public int use_animationTime { get; }
        public bool isSingleShot { get; }
        public int projectileCountPerShoot { get; }
        public int spreedAngle { get; }
        public float? chanceNotConsumeAmmo { get; }
        public ShotgunItem(int projectileID, float shootSpeed, SoundStyle sound, int? ammoID, int use_animationTime, bool isSingleShot, int projectileCountPerShoot, float? chanceNotConsumeAmmo = null) : base(DamageClass.Ranged)
        {
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.sound = sound;
            this.ammoID = ammoID;
            this.use_animationTime = use_animationTime;
            this.isSingleShot = isSingleShot;
            this.projectileCountPerShoot = projectileCountPerShoot;
            this.chanceNotConsumeAmmo = chanceNotConsumeAmmo;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.DefaultToRangedWeapon(projectileID, ammoID == null ? AmmoID.None : (int)ammoID, use_animationTime, shootSpeed, !isSingleShot);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < projectileCountPerShoot; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(spreedAngle));
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, -2f);
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= (chanceNotConsumeAmmo == null ? 1.1f : (float)chanceNotConsumeAmmo);
        }
    }
}