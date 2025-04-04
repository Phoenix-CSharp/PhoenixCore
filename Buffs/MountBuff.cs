using Terraria;
using Terraria.ModLoader;

namespace PhoenixCore.Buffs
{
	public class MountBuff : ModBuff
	{
		public int mountID { get; }
		public MountBuff ( int mountID){
			this.mountID = mountID;
		}
		public override void SetStaticDefaults() {
			Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
		}

		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(mountID, player);
			player.buffTime[buffIndex] = 10; // reset buff time
		}
	}
}
