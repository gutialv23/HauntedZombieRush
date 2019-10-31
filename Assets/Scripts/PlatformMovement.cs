using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speedX    =   1.0f;
    [SerializeField] private float resetPosX = -60.5f;
    [SerializeField] private float startPosX =  60.5f;

    protected virtual void Update()  // Called once per frame.
    {
        if (  GameManager.instance.GameActive &&
             !GameManager.instance.GameOver   )
        {
            if ( transform.position.x <= resetPosX )
            {
                transform.position = new Vector3( startPosX, transform.position.y, transform.position.z );
            }

            transform.Translate( Vector3.right * Time.deltaTime * speedX );
        }
    }
}
