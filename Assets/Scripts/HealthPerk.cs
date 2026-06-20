using UnityEngine;

public class HealthPerk : Perks
{
    protected override void Perk()
    {
        player.maxHealth += 100;
        player.health += 100;
    }
}
