using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace PhoenixCore.Core.Items.Melee{
    public class YoyoItem : GeneralItem, IMeleeItem{
        public int damage { get; }
        public int? projectileID { get; }
        public float? shootSpeed { get; }
        public SoundStyle sound { get; }
        public int? yoyoRange { get; }
        public sealed override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = (int)yoyoRange;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }
        public YoyoItem(int damage, int projectileID, float shootSpeed, SoundStyle sound, int yoyoRange) : base(DamageClass.MeleeNoSpeed){
            this.damage = damage;
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.sound = sound;
            this.yoyoRange = yoyoRange;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.UseSound = sound;
            Item.channel = true;
            Item.shoot = (int)projectileID;
            Item.shootSpeed = (float)shootSpeed;
        }
        public static readonly int[] unwantedPrefixes = [PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy];
        public override bool AllowPrefix(int pre)
        {
            if (Array.IndexOf(unwantedPrefixes, pre) > -1) return false; //reroll
            return true; //don't reroll
        }
    }
}