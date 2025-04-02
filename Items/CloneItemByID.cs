using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader;

namespace WaMCore.Core.Items
{

    public class CloneItemByID : GeneralItem, ICloneItem
    {
        public int? projectileID { get; }
        public float? shootSpeed { get; }
        public int itemID { get; }
        public CloneItemByID(int itemID, int? projectileID = null, float? shootSpeed = null)
        {
            this.itemID = itemID;
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(itemID);
            Item.shoot = projectileID == null ? Item.shoot : (int)projectileID;
            Item.shootSpeed = shootSpeed == null ? Item.shootSpeed : (float)shootSpeed;
        }
    }
}