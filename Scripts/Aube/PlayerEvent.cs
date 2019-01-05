using System;
using Server.Items;

namespace Server.Aube
{
    public delegate void OnWeaponHit(OnWeaponHitEventArgs e);

    public class OnWeaponHitEventArgs : EventArgs
    {
        public OnWeaponHitEventArgs(BaseWeapon weapon, Mobile attacker, Mobile defender, int damageGiven)
        {
            Weapon = weapon;
            Attacker = attacker;
            Defender = defender;
            DamageGiven = damageGiven;
        }

        public BaseWeapon Weapon { get; private set; }
        public Mobile Attacker { get; private set; }
        public Mobile Defender { get; private set; }
        public int DamageGiven { get; private set; }
    }

    public static class PlayerEvent
    {
        public static event OnWeaponHit OnWeaponHit;

        public static void InvokeOnWeaponHit(OnWeaponHitEventArgs e)
        {
            if (OnWeaponHit != null)
            {
                OnWeaponHit(e);
            }
        }
    }

}
