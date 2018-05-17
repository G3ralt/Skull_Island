using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 300f;
    [SerializeField]
    private float turnSpeed = 5f;

    private void Awake() {

        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

    }

    void Start () {
		
	}
	
	private void Update () {
               

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var jump = Input.GetButton("Jump");    

        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if ( vertical != 0 ) {

            characterController.SimpleMove(transform.forward * moveSpeed * vertical);

        }

    }
}
