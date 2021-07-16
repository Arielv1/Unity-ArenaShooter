using UnityEngine;
using TMPro;

using UnityEngine.UI;

public class PlayerRifleShooting : MonoBehaviour
{

    public float dealDamage = 10f;
    public float range = 20f;
    public float hitRadius = 2f;
    public float hitForce = 500f;
    public GameObject rifle;
    private Camera fpsCamera;
    public ParticleSystem muzzleFlash;

    public static int RIFLE_MAX_AMMO = 30;
    private int ammoLeft;
    public TMP_Text ammoText;

    private AudioSource rifleSFX;
    void Start()
    {
        fpsCamera = Camera.main;
        rifleSFX = rifle.GetComponent<AudioSource>();
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
        UpdateAmmoTextCanvas();
        rifleSFX.Play();
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
