using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeteWeaponBehaviour : MonoBehaviour
{
    public float destroyAfterSeconds;
    public WeaponScriptableObject weaponData;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCoolDownDuration;
    protected float currentPierce;

     void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCoolDownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;

    }
    // Start is called before the first frame update

    public float GetCurrentDamage()
    {
        return currentDamage *= FindObjectOfType<PlayerStats>().CurrentMight;
    }

    protected virtual void Start()
    {
        Destroy(gameObject,destroyAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnimyStats enemy = collision.GetComponent<EnimyStats>();
            enemy.TakeDamage(GetCurrentDamage());
        }
        else if (collision.CompareTag("Prop"))
        {
            if (collision.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(GetCurrentDamage());
            }
        }
    }
}
