using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float     topLimit   = 10f;
    [SerializeField] private float     jumpForce  = 20f;
    [SerializeField] private AudioClip jumpSound  = null;
    [SerializeField] private AudioClip deathSound = null;

    private Animator    animator    = null;
    private Rigidbody   rigidBody   = null;
    private AudioSource audioSource = null;
    private bool        jump        = false;

    private Vector3    initialPosition;
    private Quaternion initialRotation;

    // Awake is called before Start function and even if the component is not enabled.
    void Awake()
    {
        animator    = GetComponent< Animator    >();
        rigidBody   = GetComponent< Rigidbody   >();
        audioSource = GetComponent< AudioSource >();
    }

    // Start is called before the first frame update.
    void Start()
    {
        Assert.IsNotNull( animator   , "Animator component not found"    );
        Assert.IsNotNull( rigidBody  , "RigidBody component not found"   );
        Assert.IsNotNull( audioSource, "AudioSource component not found" );

        Assert.IsNotNull( jumpSound  , "Jump Sound not found"            );
        Assert.IsNotNull( deathSound , "Death Sound not found"           );

        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame.
    void Update()
    {
        if (  GameManager.instance.GameActive &&
             !GameManager.instance.GameOver   )
        {
            if ( transform.position.y < topLimit )
            {
                if ( Input.GetButtonDown( "Jump" ) ) // Jump button is set in "Project Settings -> Input".
                {
                    if ( !GameManager.instance.GameStarted )
                    {
                        GameManager.instance.PlayerStarted();
                    }

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

    // FixedUpdate is called N times per second (frame-rate independent).
    void OnCollisionEnter( Collision collision )
    {
        if ( collision.gameObject.tag == "Obstacle" )
        {
            if ( rigidBody != null )
            {
                rigidBody.velocity = new Vector3( 0, 0, 0 );
                rigidBody.AddForce( 0, 5, 0, ForceMode.Impulse );
                rigidBody.detectCollisions = false;
            }

            if ( ( audioSource != null ) &&
                 ( deathSound  != null ) )
            {
                audioSource.PlayOneShot( deathSound );
            }

            if ( animator != null )
            {
                animator.StopPlayback();
            }

            GameManager.instance.PlayerCollided();
        }
    }

    // Events.

    public void Init()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        if ( rigidBody != null )
        {
            rigidBody.velocity         = new Vector3( 0, 0, 0 );
            rigidBody.useGravity       = false;
            rigidBody.detectCollisions = true;
        }

        if ( animator != null )
        {
            animator.Play( "Idle" );
        }
    }
}
