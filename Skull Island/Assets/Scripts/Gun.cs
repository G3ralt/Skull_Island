using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField]
    [Range(0f,1.5f)]
    private float fireRate = 1;

    [SerializeField]
    [Range(1,10)]
    private int damage = 1;

    [SerializeField]
    private Transform firePoint;
    private float timer;

    [SerializeField]
    private ParticleSystem flash;

    [SerializeField]
    private AudioSource gunShot;
        
    void Update () {
        timer += Time.deltaTime;
        if (timer >= fireRate) {
            if (Input.GetButton("Fire1")) {
                timer = 0;
                FireGun();
            }
        }
	}

    private void FireGun() {
        
        //Play the gunshot flash
        if ( !flash.isPlaying ) {

            flash.Play();

        }

        gunShot.Play();        

        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;
        
        if (Physics.Raycast(ray, out hitInfo, 100)) { 

            var health = hitInfo.collider.GetComponent<Health>();

            if (health != null) {

                health.TakeDamage(damage);

            }

        }

    }
}
