using Terraria;
using Terraria.ModLoader;

namespace WaMCore.Core.Items{
    public class CloneWeapon : ModItem{
        public virtual int projectileID { get; set; }
        public virtual float shootSpeed { get; set; }
        public virtual int itemID { get; set; }
        public override void SetDefaults()
        {
            Item.CloneDefaults(itemID);
            Item.shoot = projectileID;
            Item.shootSpeed = shootSpeed;
        }
    }
}