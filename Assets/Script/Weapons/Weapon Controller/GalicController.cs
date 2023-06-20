using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalicController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedGalic = Instantiate(weaponData.Prefab);
        spawnedGalic.transform.position = transform.position;
        spawnedGalic.transform.parent = transform;
    }
}
