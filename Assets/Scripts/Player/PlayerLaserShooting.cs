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
    public GameObject muzzlePoint;
    private Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    private LineRenderer lr;

    public static int LASER_MAX_AMMO = 3;
    [SerializeField] private int ammoLeft;
    public TMP_Text ammoText;
    void Start()
    {
        fpsCamera = Camera.main;
        lr = laserGun.GetComponent<LineRenderer>();
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
            StartCoroutine(ShowLaserShot(hit.transform));
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

    IEnumerator ShowLaserShot(Transform target)
    {

        lr.SetPosition(0, muzzlePoint.transform.position);
        lr.SetPosition(1, target.position);
        lr.enabled = true;
        Debug.Log(target.position);
        // audioSource.Play();
        muzzleFlash.Play();

        yield return new WaitForSeconds(0.15f);
        lr.enabled = false;
    }
}
