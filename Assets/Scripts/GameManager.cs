using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text coinsCollectedText;
    public Text livesLeft;
    public Text gameOverText;
    public Image gameOverOverlay;
    public bool tutorialLevel = false;

    int coinsInLevel;
    int coinsCollected;
    bool collectedAllCoins = false, gameOver = false;
    BallController ball;

    public delegate void Unsubsribe();
    public static event Unsubsribe OnUnsubsribe;

    void Start()
	{
        if (tutorialLevel)
            {
            ball = FindObjectOfType<BallController>();
            coinsInLevel = GameObject.FindGameObjectsWithTag("Coin").Length;
            coinsCollected = 0;
            coinsCollectedText.text = coinsCollected.ToString() + "/" + coinsInLevel.ToString() + " coins";
            BallController.OnCoinPickup += OnCoinPickedUp;
            BallController.OnReachFinish += ReachedFinish;
            }
        else
            {
            ball = FindObjectOfType<BallController>();
            coinsInLevel = GameObject.FindGameObjectsWithTag("Coin").Length;
            coinsCollected = 0;
            BallController.OnCoinPickup += OnCoinPickedUp;
            BallController.OnLifeLost += OnLifeLost;
            BallController.OnGameOver += GameOver;
            BallController.OnReachFinish += ReachedFinish;
            coinsCollectedText.text = coinsCollected.ToString() + "/" + coinsInLevel.ToString() + " coins";
            livesLeft.text = "Lives: " + ball.lives.ToString();
            }
        
	}

    void Update()
        {
        if (gameOver)
            {
            if (Input.GetKeyDown(KeyCode.Space))
                {
                UnsubscribeFromDelegates();
                ReloadLevel();
                }
            }
        }

    

    private void ReachedFinish(Collider col)
        {
        if (collectedAllCoins)
            {
            col.GetComponent<Instruction>().SetAndActivateText("You have collected all the coins and finished the level!");
            Invoke("LoadNextLevel", 2f);
            if (OnUnsubsribe != null)
                {
                OnUnsubsribe();
                }
            UnsubscribeFromDelegates();
            }
        else
            {
            col.GetComponent<Instruction>().SetAndActivateText("You have not collected all the coins. You have " + (coinsInLevel - coinsCollected).ToString() + "/" + coinsInLevel.ToString() + " coins left.");
            
            }
        }

    private void UnsubscribeFromDelegates()
        {
        if (tutorialLevel)
            {
            BallController.OnCoinPickup -= OnCoinPickedUp;
            BallController.OnReachFinish -= ReachedFinish;
            }
        else {
            BallController.OnCoinPickup -= OnCoinPickedUp;
            BallController.OnLifeLost -= OnLifeLost;
            BallController.OnGameOver -= GameOver;
            BallController.OnReachFinish -= ReachedFinish;
            }
        }

    private void OnLifeLost()
        {
        livesLeft.text = "Lives: " + ball.lives.ToString();
        }

    void OnCoinPickedUp()
        {
        coinsCollected++;
        coinsCollectedText.text = coinsCollected.ToString() + "/" + coinsInLevel.ToString() + " coins";
        collectedAllCoins = (coinsInLevel - coinsCollected == 0);
        if (collectedAllCoins)
            {
            ball.HasCollectedAllCoins();
            coinsCollectedText.color = Color.green;
            }
        }
    void GameOver()
        {
        gameOverText.gameObject.SetActive(true);
        gameOverOverlay.gameObject.SetActive(true);
        livesLeft.text = "Game Over. Press Space to reload.";
        livesLeft.color = Color.red;
        gameOver = true;
        }
    void LoadNextLevel()
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    private void ReloadLevel()
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
