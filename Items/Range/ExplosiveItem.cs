using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhoenixCore.Items.Range
{
    [Autoload(false)]
    public class ExplosiveItem : GeneralItem, IRangeItem
    {
        public int projectileID { get; }
        public float shootSpeed { get; }
        public SoundStyle sound { get; }
        public int? ammoID { get; }
        public int use_animationTime { get; }
        public float chanceNotComsumeAmmo { get; }
        public float? chanceNotConsumeAmmo { get; }
        public bool isSingleShot { get; }
        /// <summary>
        /// Generate Explosive item (e.g. granate)
        /// 
        /// Item.useStyle = ItemUseStyleID.Swing;
        /// Item.shootSpeed = shootSpeed;
        /// Item.shoot = projectileID;
        /// Item.consumable = true;
        /// Item.UseSound = sound;
        /// Item.useAnimation = use_animationTime;
        /// Item.useTime = use_animationTime;
        /// Item.noMelee = true;
        /// Item.useAmmo = ammoID == null ? AmmoID.None : (int)ammoID;
        /// </summary>
        /// <param name="projectileID"></param>
        /// <param name="shootSpeed"></param>
        /// <param name="sound"></param>
        /// <param name="use_animationTime"></param>
        /// <param name="ammoID"></param>
        public ExplosiveItem(int projectileID, float shootSpeed, SoundStyle sound, int use_animationTime,bool isSingleShot, int? ammoID = null) : base(DamageClass.Ranged)
        {
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.sound = sound;
            this.use_animationTime = use_animationTime;
            this.ammoID = ammoID;
            this.isSingleShot = isSingleShot;

        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Type] = true;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = shootSpeed;
            Item.shoot = projectileID;
            Item.consumable = true;
            Item.UseSound = sound;
            Item.useAnimation = use_animationTime;
            Item.useTime = use_animationTime;
            Item.noMelee = true;
            Item.useAmmo = ammoID == null ? AmmoID.None : (int)ammoID;
            Item.autoReuse = isSingleShot;
        }
    }
}