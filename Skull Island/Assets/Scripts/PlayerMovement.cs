using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    private float forwardSpeed = 7.5f;

    [SerializeField]
    private float backwardSpeed = 3f;

    [SerializeField]
    private float turnSpeed = 100f;

    private void Awake() {

        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;

    }

    void Start () {
		
	}
	
	private void Update () {
<<<<<<< HEAD
        
        var horizontal = Input.GetAxis("Mouse X");
=======
               

        var horizontal = Input.GetAxis("Horizontal");
>>>>>>> 383ced89de2d5cc75287e981c5c764cee900d3a7
        var vertical = Input.GetAxis("Vertical");
        var side = Input.GetAxis("Horizontal");
        var jump = Input.GetButton("Jump");    
<<<<<<< HEAD
        
=======

        var movement = new Vector3(horizontal, 0, vertical);

>>>>>>> 383ced89de2d5cc75287e981c5c764cee900d3a7
        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if ( vertical != 0 ) {
<<<<<<< HEAD

            float moveSpeed = vertical > 0 ? forwardSpeed : backwardSpeed;
            characterController.SimpleMove(transform.forward * moveSpeed * vertical);
            characterController.SimpleMove(transform.right * moveSpeed * side);
            

        }
        
=======

            characterController.SimpleMove(transform.forward * moveSpeed * vertical);

        }

>>>>>>> 383ced89de2d5cc75287e981c5c764cee900d3a7
    }
}
