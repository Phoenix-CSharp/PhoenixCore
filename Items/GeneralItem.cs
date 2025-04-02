using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items
{
    public class GeneralItem : ModItem
    {
        public DamageClass damageClass { get; }
        public GeneralItem(){
            damageClass = DamageClass.Default;
        }
        public GeneralItem(DamageClass damageClass){
            this.damageClass = damageClass;
        }
        public override void SetDefaults()
        {
            Item.DamageType = damageClass;
        }
    }
    public interface IMeleeItem
    {
        int damage { get; }
    }
    public interface ISummonItem
    {
        int projectileID { get; }
        int damage { get; }
        float knockback { get; }
    }
    public interface IWhipItem
    {
        float shootSpeed { get; }
    }
    public interface IMinionSummonItem
    {
        SoundStyle sound { get; }
        int mana { get; }
        float minionSlotsRequired { get; }
        int minionBuff { get; }
    }
    public interface IRangeItem
    {
        int projectileID { get; }
        float shootSpeed { get; }
        SoundStyle sound { get; }
        int? ammoID { get; }
        int use_animationTime { get; }
    }
    public interface IMagicItem
    {
        int mana { get; }
        int projectileID { get; }
    }
    public interface ICloneItem
    {
        int itemID { get; }
        int? projectileID { get; }
        float? shootSpeed { get; }

    }
}