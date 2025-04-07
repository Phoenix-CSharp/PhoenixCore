using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace PhoenixCore.Items.Melee {
    [Autoload(false)]
    public class JoustingLanceItem : GeneralItem, IMeleeItem{
        public int? projectileID { get; }
        public float? shootSpeed { get; }
        public SoundStyle sound { get; }
        public int damage { get; }
        public int? yoyoRange { get; }
        public int animationTime { get; }
        public JoustingLanceItem(int projectileID, float shootSpeed, int animationTime, SoundStyle sound, int damage, int? yoyoRange = null) : base(){
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.animationTime = animationTime;
            this.sound = sound;
            this.damage = damage;
            this.yoyoRange = yoyoRange;
        }
        public override void SetDefaults()
        {
            Item.DefaultToSpear((int)projectileID, (float)shootSpeed, animationTime);
            Item.channel = true;
            Item.StopAnimationOnHurt = true;
            Item.UseSound = sound;
            Item.damage = damage;
        }
    }
}