using System.Collections.Generic;
using Terraria.Audio;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;

namespace PhoenixCore.Items.Range
{
    public class RocketLauncherItem : GeneralItem, IRangeItem
    {
        public int projectileID { get; }
        public float shootSpeed { get; }
        public SoundStyle sound { get; }
        public int? ammoID { get; }
        public int use_animationTime { get; }
        public bool isSingleShot { get; }
        public int? itemIDForChangeProjectile { get; }
        public int? projectileIDForChangeProjectile { get; }
        public float? chanceNotConsumeAmmo { get; }
        public RocketLauncherItem(int projectileID, float shootSpeed, SoundStyle sound, int ammoID, int use_animationTime,bool isSingleShot = true, int? itemIDForChangeProjectile = null, int? projectileIDForChangeProjectile = null)
        {
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.sound = sound;
            this.ammoID = ammoID;
            this.use_animationTime = use_animationTime;
            this.isSingleShot = isSingleShot;
            this.itemIDForChangeProjectile = itemIDForChangeProjectile;
            this.projectileIDForChangeProjectile = projectileIDForChangeProjectile;
        }
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ItemID.RocketLauncher;
            //for use another projectile with ItemID ammo
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>{
                {itemIDForChangeProjectile == null ? ItemID.None : (int)itemIDForChangeProjectile,
                 projectileIDForChangeProjectile == null ? ProjectileID.None : (int)projectileIDForChangeProjectile}
                });
        }
        public override void SetDefaults()
        {
            Item.DefaultToRangedWeapon(projectileID, (int)ammoID, use_animationTime, shootSpeed, !isSingleShot);
            Item.UseSound = sound;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8f, 2f);
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= (chanceNotConsumeAmmo == null ? 1.1f : (float)chanceNotConsumeAmmo);
        }
    }
}