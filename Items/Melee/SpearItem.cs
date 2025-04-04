using PhoenixCore.Core.Items;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Melee{
    public class SpearItem : GeneralItem , IMeleeItem{
        public int damage {get;}
        public int? projectileID { get; }
        public SoundStyle sound { get; }
        public float? shootSpeed { get; }
        public int? yoyoRange {get;}
        public SpearItem(int damage, SoundStyle sound, int projectileID, float shootSpeed, int? yoyoRange = null) : base(DamageClass.Melee){
            this.damage = damage;
            this.projectileID = projectileID;
            this.sound = sound;
            this.shootSpeed = shootSpeed;
            this.yoyoRange = yoyoRange;
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            ItemID.Sets.Spears[Item.type] = true;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = sound;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shootSpeed = (float)shootSpeed;
            Item.shoot = (int)projectileID;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ && Item.UseSound.HasValue) SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
            return null;
        }
    }
}