using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField]
    [Range(0f,1.5f)]
    private float fireRate = 0.2f;

    [SerializeField]
    [Range(1,10)]
    private int damage = 1;
    
    [SerializeField]
    private ParticleSystem flash;

    [SerializeField]
    private AudioSource gunShot;

    [SerializeField]
    private GameObject hitEffect;

    private float timer;
    
    private Camera mainCamera;

    private void Start() {

        mainCamera = Camera.main;

    }

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
        
        //Play the fire effect from gun
        flash.Play();
        
        //Play the gunShot sound
        gunShot.Play();        
        
        //Fire a bullet
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one * 0.5f);
        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

        //Take dmg if hit target
        if (Physics.Raycast(ray, out hitInfo, 100)) { 

            //If the collider is not trigger - skipps the sphere collider of enemies
            if ( !hitInfo.collider.isTrigger ) {

                //Get the health component if existing
                var health = hitInfo.collider.GetComponent<Health>();

                if (health != null) {

                    health.TakeDamage(damage);

                }
                else {

                    //Create the hit effect on non-enemy objects
                    var effect = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(effect, 1f);

                }

            }
            

        }

    }
}
