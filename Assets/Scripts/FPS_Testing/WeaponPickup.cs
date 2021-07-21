using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public RaycastWeapon weaponPrefab;

    private void OnTriggerEnter(Collider other)
    {
        ActiveWeapon activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();
        if (activeWeapon)
        {
            RaycastWeapon newWeapon = Instantiate(weaponPrefab);
            activeWeapon.Equip(newWeapon);
            Destroy(gameObject);
        }

        AiWeapons AiWeapons = other.gameObject.GetComponent<AiWeapons>();
        if (AiWeapons)
        {
            Debug.Log("PickWeapon AiWeapons");
            RaycastWeapon newWeapon = Instantiate(weaponPrefab);
            AiWeapons.Equip(newWeapon);
            Destroy(gameObject);
        }
    }
}
