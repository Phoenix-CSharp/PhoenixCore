using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhoenixCore.Items.Range
{
    [Autoload(false)]
    public class JavelinItem : GeneralItem, IRangeItem
    {
        public int projectileID { get; }
        public float shootSpeed { get; }
        public SoundStyle sound { get; }
        public int? ammoID { get; }
        public int use_animationTime { get; }
        public float? chanceNotConsumeAmmo { get; }
        public bool isSingleShot { get; }
        public JavelinItem(int projectileID, float shootSpeed, SoundStyle sound, int use_animationTime, bool isSingleShot, int? ammoID = null) : base(DamageClass.Ranged)
        {
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.sound = sound;
            this.use_animationTime = use_animationTime;
            this.ammoID = ammoID;
            this.isSingleShot = isSingleShot;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = use_animationTime;
            Item.useAnimation = use_animationTime;
            Item.UseSound = sound;
            Item.autoReuse = isSingleShot;
            Item.consumable = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = projectileID;
            Item.shootSpeed = shootSpeed;
        }
    }
}