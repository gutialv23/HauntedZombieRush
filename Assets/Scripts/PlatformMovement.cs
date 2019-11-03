using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private   float       speedX =   1.0f;
    [SerializeField] private   float    spawnPosX = -60.5f;
    [SerializeField] private   float    startPosX =  60.5f;
    [SerializeField] private   float   spawnDistX = 121.0f;

    [SerializeField] private   bool  randomSpawnY =  false;
    [SerializeField] protected float      topPosY =   1.0f;
    [SerializeField] protected float   bottomPosY =  -1.0f;

    // Update is called once per frame.
    protected virtual void Update()  // Called once per frame.
    {
        if (  GameManager.instance.GameActive &&
             !GameManager.instance.GameOver   )
        {
            if ( transform.position.x <= spawnPosX )
            {
                Respawn();
            }

            transform.Translate( ( -Vector3.right * Time.deltaTime * speedX ), Space.World );
        }
    }

    // Events.

    public void Init()
    {
        Respawn();

        transform.position = new Vector3( startPosX, transform.position.y, transform.position.z );
    }

    public void Respawn()
    {
        float spawnPosY = ( randomSpawnY ? Random.Range( bottomPosY, topPosY ) : transform.position.y );

        transform.position = new Vector3( transform.position.x + spawnDistX, spawnPosY, transform.position.z );
    }
}
