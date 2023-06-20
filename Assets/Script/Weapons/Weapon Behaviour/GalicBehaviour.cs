using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalicBehaviour : meleeteWeaponBehaviour
{
    List<GameObject> markedEnemies;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();   
        markedEnemies = new List<GameObject>();
    }

    // Update is called once per frame
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !markedEnemies.Contains(collision.gameObject))
        {
            EnimyStats enemy = collision.GetComponent<EnimyStats>();
            enemy.TakeDamage(GetCurrentDamage());
            markedEnemies.Add(collision.gameObject);
        }
        else if (collision.CompareTag("Prop"))
        {
            if (collision.gameObject.TryGetComponent(out BreakableProps breakable) && !markedEnemies.Contains(collision.gameObject))
            {
                breakable.TakeDamage(GetCurrentDamage());
                markedEnemies.Add(collision.gameObject);
            }
        }
    }
}
