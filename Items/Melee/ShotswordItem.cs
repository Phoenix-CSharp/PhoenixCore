using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Melee{
    [Autoload(false)]
    public class ShortswordItem : MeleeItem{
        public virtual int projectileID { get; set; }
        public virtual float shootSpeed { get; set; }
        public virtual SoundStyle sound { get; set; }
        public sealed override DamageClass damageType { get; } = DamageClass.MeleeNoSpeed;
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.DamageType = damageType;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = projectileID;
            Item.shootSpeed = shootSpeed;
            Item.UseSound = sound;
        }
    }
}