using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="EnemyScriptableObject",menuName = "ScriptableObjects/Enemy")]
public class EnimeSciptableObject : ScriptableObject
{
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField]
    private float maxHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField]
    private float damage;
    public float Damage { get => damage; set => damage = value; }
}
