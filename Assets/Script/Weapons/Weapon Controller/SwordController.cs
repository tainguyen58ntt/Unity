using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController
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
        GameObject spawnSwordKnife = Instantiate(weaponData.Prefab);
        spawnSwordKnife.transform.position = transform.position;
        spawnSwordKnife.GetComponent<SwordBehaviour>().DirectionChecker(pm.lastMoveVector);
    }
}
