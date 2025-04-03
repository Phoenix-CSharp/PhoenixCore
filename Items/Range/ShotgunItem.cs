
using Terraria.Audio;

namespace WaMCore.Core.Items.Range{
    public class ShotgunItem : GeneralItem, IRangeItem{
        public int projectileID { get; }
        public float shootSpeed { get; }
        public SoundStyle sound { get; }
        public int? ammoID { get; }
        public int use_animationTime { get; }
        public ShotgunItem(int projectileID, float shootSpeed, SoundStyle sound, )
    }
}