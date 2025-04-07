using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace PhoenixCore.Items.Magic{
    [Autoload(false)]
    public class MagicItem : GeneralItem, IMagicItem{
        public int projectileID { get; }
        public  float shootSpeed { get; }
        public  int shootTime { get; }
        public SoundStyle sound { get; }
        public int mana { get; }
        public MagicItem(int projectileID, float shootSpeed, int shootTime, SoundStyle sound, int mana) : base() {
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.shootTime = shootTime;
            this.sound = sound;
            this.mana = mana;
        }
        public override void SetDefaults()
        {
            Item.DefaultToStaff(projectileID, shootSpeed, shootTime, mana);
            Item.UseSound = sound;
        }
    }
}