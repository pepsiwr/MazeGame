using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 1.0f;
    private bool isReloading = false;

    
    //public Text maxAmmoText;

    public Animator anim;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffact;

    private float nextTimeTofire = 0f;

    public int amountIncrease;
    public Text ammoText;


    private void Start()
    {
        //anim = GetComponent<Animator>();
        if(currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
    }

    private void OnEnable()
    {
        isReloading = false;
        anim.SetBool("Reloading", false);
    }
    void Update()
    {
        if(isReloading)
        {
            return;
        }
        
        if(currentAmmo <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R) && currentAmmo<maxAmmo)
            {
                StartCoroutine(Reload());
                Reload();

                //maxAmmo -= MaxAmmo.increaseMaxAmmo;
                //MaxAmmo.maxAmmoText.text = maxAmmo.ToString();

                ammoText.text = maxAmmo.ToString();

            }
            return;
        }
        else if (Input.GetButton("Fire1") && Time.time >= nextTimeTofire)
        {
            nextTimeTofire = Time.time + 1f / fireRate;
            Shoot();
            DecreaseAmmo();
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reload");

        anim.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        
        anim.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        isReloading = false;

        
    }

    void Shoot()
    {
        
        muzzleFlash.Play(); 

        //currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target!=null)
            {
                target.TakeDamageEnemy(damage); //ลบดาเมจในสคลิปTarget
            }

            if(hit.rigidbody !=null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            
            GameObject impactGO = Instantiate(impactEffact, hit.point, Quaternion.LookRotation(hit.normal)); //ใส่เอฟเฟคเมื่อยิงโดน
            Destroy(impactGO, 2f);

        }
    }

    void DecreaseAmmo()
    {
        currentAmmo -= amountIncrease;
        ammoText.text = currentAmmo.ToString(); //ส่งข้อมูลออกไปเป็นString
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            currentAmmo += maxAmmo;
            maxAmmoText.text = currentAmmo.ToString();
        }
    }*/
}
