using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using XPT.Core.Audio.MP3Sharp.Decoding.Decoders.LayerIII;
using System;
using Terraria.Audio;

namespace WaMCore.Items.Melee{
    public class ShootingSwordItem : MeleeItem{
        public virtual int projectileID { get; set; }
        public virtual float shootSpeed { get; set; }
        public virtual SoundStyle sound { get; set; }
        public sealed override DamageClass damageType { get; } = DamageClass.Melee;
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.DamageType = damageType;
            Item.shoot = projectileID;
            Item.shootSpeed = shootSpeed;
            Item.UseSound = sound;
        }
        public sealed override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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