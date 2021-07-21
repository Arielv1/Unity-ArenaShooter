using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWeapons : MonoBehaviour
{
    RaycastWeapon currentWeapon;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    } 

    public void EquipWeapon(RaycastWeapon weapon)
    {
        currentWeapon = weapon;
        currentWeapon.transform.SetParent(transform, false); 
    }

    public void ActivateWeapon()
    {
        animator.SetBool("Equip", true);
    }
    public bool HasWeapon()
    {
        return currentWeapon != null;
    }

}
