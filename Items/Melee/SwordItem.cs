using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhoenixCore.Core.Items.Melee{
    public class SwordItem : GeneralItem, IMeleeItem{
        public int damage { get; }
        public int? projectileID { get; }
        public float? shootSpeed { get; }
        public SoundStyle sound { get; }
        public int? yoyoRange { get; }
        public int? buffID { get; }
        public int? buffTime { get; }
        public SwordItem(int damage, SoundStyle sound, int? projectileID = null, float? shootSpeed = null, int? yoyoRange = null, int? buffID = null, int? buffTime = null) : base(DamageClass.Melee){
            this.damage = damage;
            this.sound = sound;
            this.projectileID = projectileID;
            this.shootSpeed = shootSpeed;
            this.yoyoRange = yoyoRange;
            this.buffID = buffID;
            this.buffTime = buffTime;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = false;
            Item.noUseGraphic = false;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (buffID == null) return;
            target.AddBuff((int)buffID, 60 * (int)buffTime);
        }
    }
}