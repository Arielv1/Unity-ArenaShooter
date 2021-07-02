using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerGun;
    bool isTriggerHit;
    public GameObject CrosshairDefault;
    public GameObject CrosshairPickUp;
    public GameObject CrosshairWeapon;
    public float hitRange = 4f;
    public GameObject CanvasAmmo;
    void Start()
    {
        CanvasAmmo = GameObject.FindGameObjectWithTag("CanvasAmmo");
        CanvasAmmo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        //raycast forward from main camera
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, hitRange))
        {
            if (hit.transform.gameObject.tag == "PickUpGun" || hit.transform.gameObject.tag == "PickUpGrenade")
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

                    CanvasAmmo.SetActive(true);
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
