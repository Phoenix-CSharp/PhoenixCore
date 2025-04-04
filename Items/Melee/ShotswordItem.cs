using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhoenixCore.Core.Items.Melee{
    public class ShortswordItem : GeneralItem, IMeleeItem{
        public int? projectileID { get; }
        public float? shootSpeed { get; }
        public SoundStyle sound { get; }
        public int damage { get; }
        public int? yoyoRange { get; }
        public ShortswordItem(int damage, int projectileID, float shootSpeed, SoundStyle sound, int? yoyoRange = null) : base(DamageClass.MeleeNoSpeed){
            this.damage = damage;
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.sound = sound;
            this.yoyoRange = yoyoRange;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = (int)projectileID;
            Item.shootSpeed = (float)shootSpeed;
            Item.UseSound = sound;
        }
    }
}