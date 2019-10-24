using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( anim != null )
        {
            if ( Input.GetButtonDown( "Jump" ) ) // Jump button is set in "Project Settings -> Input".
            {
                anim.Play( "Jump" );
            }
        }
    }
}
