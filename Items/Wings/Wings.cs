using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhoenixCore.Items.Wings{
    [Autoload(false)]
    [AutoloadEquip(EquipType.Wings)]
    public class Wings : ModItem{
        public int flyTimeSec;
        public float flySpeed;
        public float accelerationMultiplier;
        public float fallingGlide;
        public float risingSpeed;
        public Wings(int flyTimeSec, float flySpeed, float accelerationMultiplier, float fallingGlide, float risingSpeed){
            this.flyTimeSec = flyTimeSec * 60;
            this.flySpeed = flySpeed;
            this.accelerationMultiplier = accelerationMultiplier;
            this.fallingGlide = fallingGlide;
            this.risingSpeed = risingSpeed;
        }
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<PhoenixCoreConfig>().WingsToggle;
        }
        public override void SetStaticDefaults() {
			// These wings use the same values as the solar wings
			// Fly time: 180 ticks = 3 seconds
			// Fly speed: 9
			// Acceleration multiplier: 2.5
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(flyTimeSec, flySpeed, accelerationMultiplier);
		}

		public override void SetDefaults() {
			Item.accessory = true;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = fallingGlide; // Falling glide speed
			ascentWhenRising = risingSpeed; // Rising speed
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}
    }
}