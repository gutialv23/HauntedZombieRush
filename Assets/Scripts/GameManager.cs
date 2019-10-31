using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject mainMenu = null;

    private bool gameOver    = false;
    private bool gameStarted = false;
    private bool gameActive  = false;

    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }

    public bool GameActive
    {
        get { return gameActive; }
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

        Assert.IsNotNull( mainMenu );
    }

    // Events.

    public void PlayerCollided()
    {
        gameOver = true;
    }

    public void PlayerStarted()
    {
        gameStarted = true;
    }

    public void PlayerActivated()
    {
        if ( mainMenu != null )
        {
            mainMenu.SetActive( false );
        }

        gameActive = true;
    }
}
