using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items{
    [Autoload(false)]
    public class GeneralItem : ModItem {
        public virtual DamageClass damageType { get; }
    }
    public interface MeleeItem{
        int damage { get; }
    }
    public interface ISummonItem{
        int projectileID { get; }
        int damage { get; }
        float knockback { get; }
    }
    public interface IWhipItem{
        float shotSpeed { get; }
    }
    public interface IMinionSummonItem{
        SoundStyle sound { get; }
        int mana { get; }
        float minionSlotsRequired { get; }
        int minionBuff { get; }
    }
    public interface RangeItem {
        int projectileID { get; }
        float shootSpeed { get; }
        SoundStyle sound { get; }
        int ammoID { get; }
        int use_animationTime { get; }
    }
    public interface MagicItem{
        int mana { get; }
        int projectileID { get;}
    }   
}