using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhoenixCore.Core.Items.Melee{
    public class AdvancedFlail : GeneralItem , IMeleeItem{
        public int? projectileID { get; }
        public SoundStyle sound { get; }
        public float? shootSpeed { get; }
        public int? yoyoRange { get; }
        public int damage { get; }
        public float damageMultiplier { get; }
        public AdvancedFlail(int projectileID, float shootSpeed, SoundStyle sound, int damage, float damageMultiplier, int? yoyoRange = null):base(DamageClass.MeleeNoSpeed){
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.sound = sound;
            this.damage = damage;
            this.damageMultiplier = damageMultiplier;
            this.yoyoRange = yoyoRange;
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ToolTipDamageMultiplier[Type] = damageMultiplier;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = true;
            Item.shoot = (int)projectileID;
            Item.shootSpeed = (float)shootSpeed;
            Item.UseSound = sound;
            Item.channel = true;
            Item.noMelee = true;
            Item.damage = damage;
        }

    }
}