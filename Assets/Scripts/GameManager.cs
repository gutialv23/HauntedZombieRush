using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject mainMenu     = null;
    [SerializeField] private GameObject gameOverMenu = null;
    [SerializeField] private GameObject coinMenu     = null;

    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject rock1  = null;
    [SerializeField] private GameObject rock2  = null;
    [SerializeField] private GameObject coin   = null;

    private bool gameOver    = false;
    private bool gameStarted = false;
    private bool gameActive  = false;

    private int  totalCoins = 0;

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

        Assert.IsNotNull( mainMenu     );
        Assert.IsNotNull( gameOverMenu );
        Assert.IsNotNull( coinMenu     );

        Assert.IsNotNull( player );
        Assert.IsNotNull( rock1  );
        Assert.IsNotNull( rock2  );
        Assert.IsNotNull( coin   );
    }

    // Start is called before the first frame update.
    void Start()
    {
        Init();
    }

    // Events.

    public void InitGameState()
    {
        gameOver    = false;
        gameStarted = false;
        gameActive  = false;

        totalCoins = 0;

        if ( player != null )
        {
            ZombieController zc = player.GetComponent<ZombieController>();

            if ( zc != null ) zc.Init();
        }

        if ( rock1 != null )
        {
            RockMovement rm = rock1.GetComponent<RockMovement>();

            if ( rm != null ) rm.Init();
        }

        if ( rock2 != null )
        {
            RockMovement rm = rock2.GetComponent<RockMovement>();

            if ( rm != null ) rm.Init();
        }

        if ( coin != null )
        {
            RockMovement rm = coin.GetComponent<RockMovement>();

            if ( rm != null ) rm.Init();
        }
    }

    public void Init()
    {
        if ( gameOverMenu != null ) gameOverMenu.SetActive( false );
        if (     mainMenu != null )     mainMenu.SetActive( true  );
    }

    public void PlayerActivated()
    {
        InitGameState();

        if (     mainMenu != null )     mainMenu.SetActive( false );
        if ( gameOverMenu != null ) gameOverMenu.SetActive( false );

        gameActive = true;
    }

    public void PlayerCollided()
    {
        Text coinText = coinMenu.GetComponent<Text>();

        if ( coinText != null ) coinText.text = "Coins: " + totalCoins;

        if ( gameOverMenu != null ) gameOverMenu.SetActive( true );

        gameOver = true;
    }

    public void PlayerStarted()
    {
        gameStarted = true;
    }

    public void CoinCollected()
    {
        ++totalCoins;
    }
}
