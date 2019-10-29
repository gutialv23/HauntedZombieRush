using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 20f;

    private Animator  animator  = null;
    private Rigidbody rigidBody = null;
    private bool      jump      = false;

    // Start is called before the first frame update.
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame.
    void Update()
    {
        if ( ( animator  != null ) &&
             ( rigidBody != null ) )
        {
            if ( Input.GetButtonDown( "Jump" ) ) // Jump button is set in "Project Settings -> Input".
            {
                animator.Play( "Jump" );
                rigidBody.useGravity = true;
                jump = true;
            }
        }
    }

    // FixedUpdate is called N times per second (frame-rate independent).
    void FixedUpdate()
    {
        if ( jump )
        {
            jump = false;

            rigidBody.velocity = new Vector3( 0, 0, 0 );
            rigidBody.AddForce( 0, jumpForce, 0, ForceMode.Impulse );
        }
    }
}
