using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Summon
{
    public class SummonItem : GeneralItem, ISummonItem, IMinionSummonItem
    {
        public int projectileID { get; }
        public int damage { get; }
        public float knockback { get; }
        public SoundStyle sound { get; }
        public int mana { get; }
        public int minionBuff { get; }
        public float minionSlotsRequired { get; }
        public SummonItem(int projectileID, int minionBuff, float minionSlotsRequired, SoundStyle sound, int mana = 20, int damage = 1, float knockback = 1f) : base(DamageClass.Summon)
        {
            this.projectileID = projectileID;
            this.minionBuff = minionBuff;
            this.minionSlotsRequired = minionSlotsRequired;
            this.sound = sound;
            this.mana = mana;
            this.damage = damage;
            this.knockback = knockback;
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
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld;
        }
    }
}