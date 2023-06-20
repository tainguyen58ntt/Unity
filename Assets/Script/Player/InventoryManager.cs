using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public List<WeaponController> weaponSlots = new List<WeaponController>(6);
    public int[] weaponLevels = new int[6]; 
    public List<Image> weaponUISlots = new List<Image>(6);
    public List<PassiveItems> passItemSlots = new List<PassiveItems>(6); 
    public int[] passiveItemLevels = new int[6];

    public List<Image> passiveUISlots = new List<Image>(6);
    public void AddWeapon(int slotIndex, WeaponController weapon) // add a weapon to specific slot
    {
        weaponSlots[slotIndex] = weapon;
        weaponLevels[slotIndex] = weapon.weaponData.Level;
        weaponUISlots[slotIndex].enabled = true;    
        weaponUISlots[slotIndex].sprite = weapon.weaponData.Icon;
    }

    public void AddPassiveItem(int sloIndex, PassiveItems passiveItem) //add passive item to specific slot
    {
        passItemSlots[sloIndex] = passiveItem;
        passiveItemLevels[sloIndex] = passiveItem.passiveItemData.Level;
        passiveUISlots[sloIndex].enabled = true;    
        passiveUISlots[sloIndex].sprite = passiveItem.passiveItemData.Icon;
    }

    public void LevelUpWeapon(int slotIndex)
    {
        if(weaponSlots.Count > slotIndex)
        {
            WeaponController weapon = weaponSlots[slotIndex];
            if (!weapon.weaponData.NextLevelPrefab)
            {
                Debug.LogError("NO EXIST LEVEL FOR " + weapon.name);
                return;
            }

            GameObject upgradedWeapon = Instantiate(weapon.weaponData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradedWeapon.transform.SetParent(transform);
            AddWeapon(slotIndex, upgradedWeapon.GetComponent<WeaponController>());
            Destroy(weapon.gameObject);
            weaponLevels[slotIndex] = upgradedWeapon.GetComponent<WeaponController>().weaponData.Level;

        }
    }



    public void LevelUpPassiveItem(int slotIndex)
    {
        if (passItemSlots.Count > slotIndex)
        {   
            PassiveItems passiveItems = passItemSlots[slotIndex];

            if (!passiveItems.passiveItemData.NextLevelPrefab)
            {
                Debug.LogError("NO EXIST LEVEL FOR " + passiveItems.name);
                return;
            }   
            GameObject upgradedPassiveItem = Instantiate(passiveItems.passiveItemData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradedPassiveItem.transform.SetParent(transform);
            AddPassiveItem(slotIndex, upgradedPassiveItem.GetComponent<PassiveItems>());
            Destroy(passiveItems.gameObject);
            passiveItemLevels[slotIndex] = upgradedPassiveItem.GetComponent<PassiveItems>().passiveItemData.Level;

        }
    }
 
}
