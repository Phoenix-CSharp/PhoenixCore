using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace PhoenixCore.Items
{
    [Autoload(false)]
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
        int? projectileID { get; }
        float? shootSpeed { get; }
        SoundStyle sound { get; }
        int? yoyoRange { get; }
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
        float? chanceNotConsumeAmmo { get; }
        bool isSingleShot { get; }
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