using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Magic{
    [Autoload(false)]
    public class MagicItem : Base_MagicItem{
        public sealed override DamageClass damageType { get;} = DamageClass.Magic;
        public virtual float pushForwardSpeed { get; }
        public virtual int singleShotTime { get; }
        public virtual SoundStyle sound { get; }
        public virtual bool isStaff { get; }
        public override void SetDefaults()
        {
            Item.DefaultToStaff(projectileID, pushForwardSpeed, singleShotTime, mana);
            Item.UseSound = sound;
        }
    }
}