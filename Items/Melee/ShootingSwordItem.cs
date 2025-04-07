using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace PhoenixCore.Items.Melee{
    [Autoload(false)]
    public class ShootingSwordItem : GeneralItem, IMeleeItem{
        public int? projectileID { get; }
        public float? shootSpeed { get; }
        public SoundStyle sound { get; }
        public int damage { get; }
        public int? yoyoRange { get; }
        public ShootingSwordItem(int damage, int projectileID, float shootSpeed, SoundStyle sound, int? yoyoRange = null) : base(DamageClass.Melee){
            this.damage = damage;
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.sound = sound;
            this.yoyoRange = yoyoRange;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.shoot = (int)projectileID;
            Item.shootSpeed = (float)shootSpeed;
            Item.UseSound = sound;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float cL = target.Y; //ceilingLimit
            if (cL > player.Center.Y - 200f) cL = player.Center.Y - 200f;
            for (int i = 0; i < 3; i++){
                position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                position.Y -= 100 * i;
                Vector2 heading = target - position;
                if (heading.Y < 0f) heading.Y *= -1f;
                if (heading.Y < 20f) heading.Y = 20f;
                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, cL);
            }
            return false;
        }
    }
}