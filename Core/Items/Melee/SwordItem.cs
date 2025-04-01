using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Melee{
    public class SwordItem : MeleeItem{
        public sealed override DamageClass damageType { get; } = DamageClass.Melee;
        public virtual SoundStyle sound { get; set; }
        public override void SetDefaults()
        {
            Item.DamageType = damageType;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = false;
            Item.noUseGraphic = false;
        }
    }
}