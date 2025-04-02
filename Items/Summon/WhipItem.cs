using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaMCore.Core.Items.Summon{
    public class WhipItem : GeneralItem, ISummonItem, IWhipItem{
        public sealed override DamageClass damageType { get; } = DamageClass.SummonMeleeSpeed; 
        public int projectileID { get; }
        public int damage { get; }
        public float knockback { get; }
        public float shotSpeed { get; }
        public WhipItem(int projectileID, int damage, float knockback, float shotSpeed){
            this.projectileID = projectileID;
            this.damage = damage;
            this.knockback = knockback;
        }
        public override void SetDefaults()
        {
            Item.DefaultToWhip(projectileID, damage, knockback, shotSpeed);
        }
        public sealed override bool MeleePrefix()
        {
            return true;
        }
    }
}