using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace WaMCore.Items.Melee{
    public class YoyoItem : MeleeItem{
        public sealed override DamageClass damageType { get; } = DamageClass.MeleeNoSpeed;
        public virtual int projectileID { get; set; }
        public virtual float shootSpeed { get; set; }
        public virtual SoundStyle sound { get; set; }
        public virtual int yoyoRange { get; set; }
        public sealed override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = yoyoRange;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.UseSound = sound;
            Item.DamageType = damageType;
            Item.channel = true;
            Item.shoot = projectileID;
            Item.shootSpeed = shootSpeed;
        }
        public static readonly int[] unwantedPrefixes = [PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy];
        public override bool AllowPrefix(int pre)
        {
            if (Array.IndexOf(unwantedPrefixes, pre) > -1) return false; //reroll
            return true; //don't reroll
        }
    }
}