using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWeaponPickup : MonoBehaviour
{
    public RaycastWeapon weaponPrefab;

    private void OnTriggerEnter(Collider other)
    {
        AiWeapons AiWeapons = other.gameObject.GetComponent<AiWeapons>();
        if (AiWeapons && (other.gameObject.name == "Player" || other.gameObject.name == "AI_Commander"))
        {
            // Commander
            RaycastWeapon newCommanderWeapon = Instantiate(weaponPrefab);
            AiWeapons.Equip(newCommanderWeapon);
            // Supporter
            RaycastWeapon newSupporterWeapon = Instantiate(weaponPrefab);
            other.gameObject.GetComponent<AiAgent>().supporter.GetComponent<AiWeapons>().Equip(newSupporterWeapon);
            Destroy(gameObject);
        }
    }
}
