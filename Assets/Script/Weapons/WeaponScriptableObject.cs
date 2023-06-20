using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="WeaponScriptablObject",menuName ="ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject 
{
    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    [SerializeField]
    private float damage;
    public float Damage { get => damage; set => damage = value; }

    [SerializeField]
    private float speed;
    public float Speed { get => speed; set => speed = value; }

    [SerializeField]
    private float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; set => cooldownDuration = value; }

    [SerializeField]
    private int pierce;
    public int Pierce { get => pierce; set => pierce = value; }

    [SerializeField]
    int level;
    public int Level { get => level; private set => level = value; }

    [SerializeField]
    GameObject nextLevelPrefab;
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }

    [SerializeField]
    Sprite icon;
    public Sprite Icon { get => icon;private set => icon = value; }


}
