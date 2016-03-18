using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DisplayController : MonoBehaviour {
    public Text distanceText;
    public Text peanutsText;
    public Text rocksText;
    public Text scoreText;
    [Header("Game Objects")]
    public GameObject gameInProgress;
    public GameObject gameOver;
    public GameObject pauseMenu;
    [Header("Buttons")]
    public GameObject pausebutton;
    [Header("Miscellaneous")]
    public float scoreSpeed;
    public string sceneRestartName;
    private int distanceRan = 0;
    private int peanutsCount = 0;
    private int rocksCount = 0;
    private float previousTime;
    public bool isGameOver;

    void Start()
    {
        distanceText.text = distanceRan + "m";
        peanutsText.text = "x" + peanutsCount;
        rocksText.text = "x" + rocksCount;
        previousTime = Time.time;
        isGameOver = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            increasePeanuts();
            increaseRocks();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            reducePeanuts();
            reduceRocks();
        }
    }
    void FixedUpdate()
    {
        float currentTime = Time.time;
        if (currentTime - previousTime > 1/scoreSpeed && !isGameOver)
        {
            updateTime();
            distanceRan++;
            distanceText.text = distanceRan + "m";

        }
        else if (isGameOver)
        {
            gameOverDisplay();
        }

    }

    float updateTime()
    {
        previousTime = Time.time;
        return previousTime;
    }
	
    public void reducePeanuts()
    {
        peanutsCount--;
        peanutsText.text = "x" + peanutsCount;

    }
    public void increasePeanuts()
    {
        peanutsCount++;
        peanutsText.text = "x" + peanutsCount;
    }

    public void reduceRocks()
    {
        rocksCount--;
        rocksText.text = "x" + rocksCount;
    }
    public void increaseRocks()
    {
        rocksCount++;
        rocksText.text = "x" + rocksCount;
    }
    public void pauseMenuDisplayOn()
    {
        pausebutton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

    }
    public void pauseMenuDisplayOff()
    {
        pauseMenu.SetActive(false);
        pausebutton.SetActive(true);
        Time.timeScale = 1;
    }
    public void gameOverDisplay()
    {
        
        gameInProgress.SetActive(false);
        scoreText.text = "distance: " + distanceRan + "\n peanuts: 5 x " + peanutsCount + "\n score: " + (int)(distanceRan + 5 * peanutsCount) + "\n record: some value";
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneRestartName);

    }

}
