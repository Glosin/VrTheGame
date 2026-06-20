using UnityEngine;

public class GunDamagePerk : Perks
{
    protected override void Perk()
    {
        player.damage += 100;
    }
}
