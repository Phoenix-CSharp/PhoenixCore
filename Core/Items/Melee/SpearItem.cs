using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Melee{
    public class SpearItem : MeleeItem{
        public sealed override DamageClass damageType { get; } = DamageClass.Melee;
        public virtual SoundStyle sound { get; set; }
        public virtual int projectileID { get; set; }
        public virtual float shootSpeed { get; set; }
        public sealed override void SetStaticDefaults()
        {
            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            ItemID.Sets.Spears[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = sound;
            Item.DamageType = damageType;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shootSpeed = shootSpeed;
            Item.shoot = projectileID;
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