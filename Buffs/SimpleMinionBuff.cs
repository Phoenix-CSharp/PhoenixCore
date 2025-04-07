using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhoenixCore.Buffs{
    public class SimpleMinionBuff : ModBuff
	{
		public Projectile projectile;
		public SimpleMinionBuff(Projectile projectile){
			this.projectile = projectile;
		}
		public override void SetStaticDefaults() {
			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
		}

		public override void Update(Player player, ref int buffIndex) {
			// If the minions exist reset the buff time, otherwise remove the buff from the player
			if (player.ownedProjectileCounts[projectile.type] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}