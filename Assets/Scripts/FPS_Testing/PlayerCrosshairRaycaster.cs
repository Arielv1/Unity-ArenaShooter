using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshairRaycaster : MonoBehaviour
{
    public float hitRange = 4f;

    public RaycastWeapon riflePrefab;
    public RaycastWeapon laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //raycast forward from main camera
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, hitRange))
        {
            if (hit.transform.gameObject.tag == "PickupRifle" || hit.transform.gameObject.tag == "PickupLaser" || hit.transform.gameObject.tag == "PickUpGrenade")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.transform.gameObject.tag == "PickupRifle")
                    {
                        ActiveWeapon activeWeapon = gameObject.GetComponent<ActiveWeapon>();
                        if (activeWeapon)
                        {
                            Debug.Log("got here!1");
                            RaycastWeapon newWeapon = Instantiate(riflePrefab);
                            activeWeapon.Equip(newWeapon);
                            // Supporter
                            RaycastWeapon newSupporterWeapon = Instantiate(riflePrefab);
                            gameObject.GetComponent<PlayerController>().supporter.GetComponent<AiWeapons>().Equip(newSupporterWeapon);
                        }
                    }
                    else if (hit.transform.gameObject.tag == "PickupLaser")
                    {
                        ActiveWeapon activeWeapon = gameObject.GetComponent<ActiveWeapon>();
                        if (activeWeapon)
                        {
                            RaycastWeapon newWeapon = Instantiate(laserPrefab);
                            activeWeapon.Equip(newWeapon);
                            // Supporter
                            RaycastWeapon newSupporterWeapon = Instantiate(laserPrefab);
                            gameObject.GetComponent<PlayerController>().supporter.GetComponent<AiWeapons>().Equip(newSupporterWeapon);
                        }
                    }
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
    }
}
