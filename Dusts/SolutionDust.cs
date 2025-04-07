using Terraria.ModLoader;

namespace PhoenixCore.Dusts
{
	[Autoload(false)]
	public class SolutionDust : ModDust
	{
		public int updateType { get; }
		public SolutionDust(int updateType){ this.updateType = updateType; }
		public override void SetStaticDefaults() {
			UpdateType = updateType;
		}
	}
}