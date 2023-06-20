using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSelector : MonoBehaviour
{
    public static CharactersSelector instance;
    public CharacterSctiptablObject CharacterData;

     void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static CharacterSctiptablObject GetData()
    {
        return instance.CharacterData;
    }

    public void SelectWeapon(CharacterSctiptablObject character)
    {
        CharacterData = character;
    }
    public void DestroySigleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
