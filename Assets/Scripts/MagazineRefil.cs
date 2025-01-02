using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MagazineRefil : MonoBehaviour
{
    public bool isMagazine = true;
    public Magazine magazine;
    public GameObject spawnLocation;
    
    public void Update()
    {
        if (!isMagazine)
        {
            Instantiate(magazine, spawnLocation.transform.position, spawnLocation.transform.rotation);
            ChangeStateMagazine();
        }
    }

    public void ChangeStateMagazine()
    {
        isMagazine = !isMagazine;
    }
}
