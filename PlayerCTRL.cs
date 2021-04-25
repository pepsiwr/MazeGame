using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{
    CharacterController controller;
    Animator anim;
    Rigidbody rb;

    float xInput, zInput;
    public float speed = 5;
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        //Camera.main.transform.LookAt(this.transform.position); //ให้กล้องติดตาม
    }


    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            xInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            anim.SetBool("BoolWalk", true);
            transform.Translate(xInput, 0, 0);
        }
        else if(Input.GetButton("Vertical"))
        {
            zInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            anim.SetBool("BoolWalk", true);
            transform.Translate(0, 0, zInput);
        }
        else
        {
            anim.SetBool("BoolWalk", false);
        }

        if(Input.GetMouseButtonDown(0)||Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("BoolShoot", true);
            Shoot();
        }
        else
        {
            anim.SetBool("BoolShoot", false);
        }

        
    }

    void Shoot()
    {
        //muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name); //ปริ้นชื่อObject

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamageEnemy(damage);
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        
    }*/
}
