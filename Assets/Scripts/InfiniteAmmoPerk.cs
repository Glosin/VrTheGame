using UnityEngine;

public class InfiniteAmmoPerk : Perks
{
    protected override void Perk()
    {
        FindAnyObjectByType<SimpleShoot>().infiniteAmmoPerk = true;
    }
}
