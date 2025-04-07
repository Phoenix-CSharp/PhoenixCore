using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhoenixCore.Buffs
{
	[Autoload(false)]
	/// <summary>
	/// Only a single weapon imbue buff can apply to a player at a time, Main.meleeBuff ensures that this restriction is met.
	/// See also ExampleFlask and ExampleWeaponEnchantmentPlayer.
	/// </summary>
	public class WeaponImbue : ModBuff
	{
		public override void SetStaticDefaults() {
			BuffID.Sets.IsAFlaskBuff[Type] = true;
			Main.meleeBuff[Type] = true;
			Main.persistentBuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.MeleeEnchantActive = true; // MeleeEnchantActive indicates to other mods that a weapon imbue is active.
		}
	}
}
