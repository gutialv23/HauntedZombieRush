using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    [ SerializeField ] private float    topPosition =  1.0f;
    [ SerializeField ] private float bottomPosition = -1.0f;
    [ SerializeField ] private float speed          =  1.0f;
    [ SerializeField ] private float waitTime       =  0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( MoveUpDown() );
    }

    IEnumerator MoveUpDown()
    {
        Vector3 direction = Vector3.down; // Start direction.

        while ( true )
        {
            transform.localPosition += ( direction * Time.deltaTime * speed );

            bool wait = false;

                 if ( ( transform.localPosition.y < bottomPosition ) && ( direction != Vector3.up   ) ) { direction = Vector3.up;   wait = true; }
            else if ( ( transform.localPosition.y >    topPosition ) && ( direction != Vector3.down ) ) { direction = Vector3.down; wait = true; }

            yield return ( ( wait ) ? new WaitForSeconds( waitTime ) : null );
        }
    }
}
