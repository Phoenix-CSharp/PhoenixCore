using Terraria;

namespace PhoenixCore.Core.Items.Summon
{
    public class WhipItem : GeneralItem, ISummonItem, IWhipItem
    {
        
        public int projectileID { get; }
        public int damage { get; }
        public float knockback { get; }
        public float shootSpeed { get; }
        public WhipItem(int projectileID, int damage, float knockback, float shootSpeed) : base()
        {
            this.projectileID = projectileID;
            this.damage = damage;
            this.knockback = knockback;
            this.shootSpeed = shootSpeed;
        }
        public override void SetDefaults()
        {
            Item.DefaultToWhip(projectileID, damage, knockback, shootSpeed);
        }
        public sealed override bool MeleePrefix()
        {
            return true;
        }
    }
}