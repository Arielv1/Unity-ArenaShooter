using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerLaserShooting : MonoBehaviour
{

    public float dealDamage = 75f;
    public float range = 20f;
    public float hitRadius = 2f;
    public float hitForce = 2500f;
    public GameObject laserGun;
    private Camera fpsCamera;
    public ParticleSystem muzzleFlash;

    public static int LASER_MAX_AMMO = 3;
    private int ammoLeft;
    public TMP_Text ammoText;
    void Start()
    {
        fpsCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!laserGun.activeSelf || ammoLeft <= 0)
        {
            return;
        }
        ammoLeft--;
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            if (hit.transform.tag != "Ally" && hit.transform.tag != "Enemy" && hit.transform.tag != "Ground")
            {

                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.AddForce(-hit.normal * hitForce);
                }
            }
        }
        UpdateAmmoTextCanvas();
    }

    public void SetAmmo(int amount)
    {
        ammoLeft = amount;
        UpdateAmmoTextCanvas();
    }

    public void UpdateAmmoTextCanvas()
    {
        ammoText.text = ammoLeft.ToString();
    }
}
