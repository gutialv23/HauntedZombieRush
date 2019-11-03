using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : PlatformMovement
{
    [SerializeField] private bool  moveUpDown = true;
    [SerializeField] private float speed      = 1.0f;
    [SerializeField] private float waitTime   = 0.5f;

    [SerializeField] private GameObject other = null;

    void Start()  // Called before the first frame update.
    {
        if ( moveUpDown )
        {
            StartCoroutine( MoveUpDown() );
        }
    }

    protected override void Update()  // Called once per frame.
    {
        if ( GameManager.instance.GameStarted )
        {
            base.Update();
        }
    }

    IEnumerator MoveUpDown()
    {
        Vector3 direction = Vector3.down; // Start direction.

        while ( true )
        {
            transform.localPosition += ( direction * Time.deltaTime * speed );

            bool wait = false;

                 if ( ( transform.localPosition.y < bottomPosY ) && ( direction != Vector3.up   ) ) { direction = Vector3.up;   wait = true; }
            else if ( ( transform.localPosition.y >    topPosY ) && ( direction != Vector3.down ) ) { direction = Vector3.down; wait = true; }

            yield return ( ( wait ) ? new WaitForSeconds( waitTime ) : null );
        }
    }
}
