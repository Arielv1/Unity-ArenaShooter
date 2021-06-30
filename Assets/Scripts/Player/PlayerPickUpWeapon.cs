using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerGun;
    bool isTriggerHit;
    public GameObject CrosshairDefault;
    public GameObject CrosshairPickUp;
    public GameObject CrosshairWeapon;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        //raycast forward from main camera
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.distance < 4 && 
                hit.transform.gameObject.tag == "PickUpGun" || hit.transform.gameObject.tag == "PickUpGrenade")
            {
                if (!isTriggerHit)
                {
                    isTriggerHit = true;
                    CrosshairDefault.SetActive(false);
                    CrosshairWeapon.SetActive(false);
                    CrosshairPickUp.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.transform.gameObject.tag == "PickUpGun")
                    {
                        CrosshairDefault.SetActive(false);
                        CrosshairPickUp.SetActive(false);
                        CrosshairWeapon.SetActive(true);

                        PlayerGun.SetActive(true);
                        hit.transform.gameObject.SetActive(false);
                    } 
                    else if(hit.transform.gameObject.tag == "PickUpGrenade")
                    {
                        GetComponent<GrenadeThrower>().IncrementNumGrenades();
                        hit.transform.gameObject.SetActive(false);
                    }
                    
                }
            }
            else
            {
                if (isTriggerHit && !PlayerGun.activeSelf)
                {
                    isTriggerHit = false;
              
                    CrosshairWeapon.SetActive(false);
                    CrosshairPickUp.SetActive(false);
                    CrosshairDefault.SetActive(true);

                }

            }
        }
    }
}
