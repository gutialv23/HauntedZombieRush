using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private bool gameOver    = false;
    private bool gameStarted = false;

    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }

    // Awake is called before Start function and even if the component is not enabled.
    void Awake()
    {
        if ( instance == null )
        {
            instance = this;
        }
        else if ( instance != this )
        {
            Destroy( gameObject );
        }

        DontDestroyOnLoad( gameObject );  // Avoid destroying and creating the GameManager between scenes.
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerCollided()
    {
        gameOver = true;
    }

    public void PlayerStarted()
    {
        gameStarted = true;
    }
}
