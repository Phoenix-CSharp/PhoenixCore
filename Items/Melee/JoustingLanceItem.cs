using Terraria;
using Terraria.GameContent.RGB;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Melee {
    [Autoload(false)]
    public class JoustingLanceItem : MeleeItem{
        public sealed override DamageClass damageType { get; } = DamageClass.MeleeNoSpeed;
        public virtual int projectileID { get; set; }
        public virtual float pushForwardSpeed { get; set; }
        public virtual int animationTime { get; set; }
        public override void SetDefaults()
        {
            Item.DefaultToSpear(projectileID, pushForwardSpeed, animationTime);
            Item.channel = true;
            Item.StopAnimationOnHurt = true;
        }
    }
}