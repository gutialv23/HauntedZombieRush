using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float     jumpForce = 20f;
    [SerializeField] private AudioClip jumpSound = null;

    private Animator    animator    = null;
    private Rigidbody   rigidBody   = null;
    private AudioSource audioSource = null;
    private bool        jump        = false;

    // Start is called before the first frame update.
    void Start()
    {
        animator    = GetComponent< Animator    >();
        rigidBody   = GetComponent< Rigidbody   >();
        audioSource = GetComponent< AudioSource >();
    }

    // Update is called once per frame.
    void Update()
    {
        if ( Input.GetButtonDown( "Jump" ) ) // Jump button is set in "Project Settings -> Input".
        {
            if ( animator != null )
            {
                animator.Play( "Jump" );
            }

            if ( ( audioSource != null ) &&
                 ( jumpSound   != null ) )
            {
                audioSource.PlayOneShot( jumpSound );
            }

            if ( rigidBody != null )
            {
                rigidBody.useGravity = true;
            }

            jump = true;
        }
    }

    // FixedUpdate is called N times per second (frame-rate independent).
    void FixedUpdate()
    {
        if ( jump )
        {
            jump = false;

            if ( rigidBody != null )
            {
                rigidBody.velocity = new Vector3( 0, 0, 0 );
                rigidBody.AddForce( 0, jumpForce, 0, ForceMode.Impulse );
            }
        }
    }
}
