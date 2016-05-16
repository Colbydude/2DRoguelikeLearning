using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;  // Static instance of GameManager, which allows it to be accessed by any other script.

    private BoardManager boardScript;           // Store a reference to our BoardManager, which will set up the level.
    private int level = 3;                      // Current level number.

    // Awake is always called before any Start functions.
    void Awake()
    {
        // Check if the instance already exists, if not, set it to this.
        if (instance == null)
            instance = this;
        // Otherwise if it does and is not this, destroy this.
        // This enforces the singleton pattern, so there can only ever be one instance of GameManager.
        else if (instance != this)
            Destroy(gameObject);

        // Persist this object throughout all scenes.
        DontDestroyOnLoad(gameObject);

        // Get a component reference to the attached BoardManager script.
        boardScript = GetComponent<BoardManager>();

        // Call the InitGame function to initialize the first level.
        InitGame();
    }

    // Initializes the game for each level.
    void InitGame()
    {
        // Call the SetupScene function of the BoardManager script, pass in the current level.
        boardScript.SetupScene(level);
    }

    // Update is called once per frame.
    void Update()
    {
        // TODO:
    }
}
