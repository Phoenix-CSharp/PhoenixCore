using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PhoenixCore.Items.Summon
{
    [Autoload(false)]
    public class SummonItem : GeneralItem, ISummonItem, IMinionSummonItem
    {
        public int projectileID { get; }
        public int damage { get; }
        public float knockback { get; }
        public SoundStyle sound { get; }
        public int mana { get; }
        public int minionBuff { get; }
        public float minionSlotsRequired { get; }
        public int use_animationTime { get; }
        public SummonItem(int projectileID, int minionBuff, float minionSlotsRequired, SoundStyle sound,int use_animationTime, int mana = 20, int damage = 1, float knockback = 1f) : base(DamageClass.Summon)
        {
            this.projectileID = projectileID;
            this.minionBuff = minionBuff;
            this.minionSlotsRequired = minionSlotsRequired;
            this.sound = sound;
            this.mana = mana;
            this.damage = damage;
            this.knockback = knockback;
            this.use_animationTime = use_animationTime;
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
            ItemID.Sets.StaffMinionSlotsRequired[Item.type] = minionSlotsRequired;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = damage;
            Item.knockBack = knockback;
            Item.mana = mana;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = sound;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = projectileID;
            Item.buffType = minionBuff;
            Item.useTime = use_animationTime;
            Item.useAnimation = use_animationTime;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(Item.buffType, 2);

			// Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;

			// Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
			return false;
		}
    }
}