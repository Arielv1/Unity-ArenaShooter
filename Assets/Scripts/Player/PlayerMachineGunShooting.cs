using UnityEngine;
using TMPro;

using UnityEngine.UI;

public class PlayerMachineGunShooting : MonoBehaviour
{

    public float dealDamage = 10f;
    public float range = 100f;
    public float hitRadius = 2f;
    public float hitForce = 500f;
    public GameObject rifle;
    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;

    public int ammoLeft;
    public TMP_Text ammoText;
    void Start()
    {
        ammoLeft = 30;
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
        
        if (!rifle.activeSelf || ammoLeft <= 0)
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
        ammoText.text = ammoLeft.ToString();
    }
}
