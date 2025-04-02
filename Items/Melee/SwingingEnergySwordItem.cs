using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace WaMCore.Core.Items.Melee{
    [Autoload(false)]
    public class SwingingEnergySwordItem : MeleeItem{
        public sealed override DamageClass damageType { get; } = DamageClass.Melee;
        public virtual SoundStyle sound { get; set; }
        public virtual int projectileID { get; set; }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = sound;
            Item.DamageType = damageType;
            Item.shoot = projectileID;
            Item.noMelee = true;
            Item.shootsEveryUse = true;
            Item.autoReuse = true;
        }
        public sealed override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item);
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI);
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}