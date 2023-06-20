using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : ProjectLineWeaponBehaviour
{



    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}
