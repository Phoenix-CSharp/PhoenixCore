using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;

namespace PhoenixCore.Items.Magic{
    [Autoload(false)]
    public class StaffItem : GeneralItem, IMagicItem{
        public float shootSpeed { get; }
        public int shootTime { get; }
        public SoundStyle sound { get; }
        public int mana { get; }
        public int projectileID { get; }
        public override void SetDefaults()
        {
            Item.DefaultToStaff(projectileID, shootSpeed, shootTime, mana);
            Item.UseSound = sound;
        }
        public sealed override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }
    }
}