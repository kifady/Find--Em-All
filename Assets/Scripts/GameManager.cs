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
    public int coinsNeeded;
    public AudioClip finish; 

    int coinsInLevel;
    int coinsCollected;
    string finishText;
    bool collectedAllCoins = false, gameOver = false;
    BallController ball;

    void Start()
	{
        coinsCollected = 0;
        coinsInLevel = GameObject.FindGameObjectsWithTag("Coin").Length;
        coinsCollectedText.text = coinsCollected.ToString() + "/" + coinsNeeded.ToString() + " coins";
        ball = FindObjectOfType<BallController>();

        if (tutorialLevel)
            {
            BallController.OnCoinPickup += OnCoinPickedUp;
            BallController.OnReachFinish += ReachedFinish;
            }
        else
            {
            BallController.OnCoinPickup += OnCoinPickedUp;
            BallController.OnLifeLost += OnLifeLost;
            BallController.OnGameOver += GameOver;
            BallController.OnReachFinish += ReachedFinish;
            livesLeft.text = "Lives: " + ball.lives.ToString();
            }
	}

    void Update()
        {
        if (gameOver)
            {
            if (Input.GetKeyDown(KeyCode.Space))
                {
                ReloadLevel();
                }
            }
        }

    

    private void ReachedFinish(GameObject finish)
        {
        if (collectedAllCoins)
            {
            finish.GetComponent<Instruction>().SetAndActivateText(finishText);
            SoundManager.instance.PlaySound(this.finish, finish.transform.position);
            Invoke("LoadNextLevel", 2f);
            }
        else
            {
            finish.GetComponent<Instruction>().SetAndActivateText(finishText);
            }
        }

    private void OnLifeLost()
        {
        livesLeft.text = "Lives: " + ball.lives.ToString();
        }

    void OnCoinPickedUp()
        {
        coinsCollected++;
        coinsCollectedText.text = coinsCollected.ToString() + "/" + coinsNeeded.ToString() + " coins";
        collectedAllCoins = (coinsNeeded - coinsCollected<=0);
        if (collectedAllCoins)
            {
            if (coinsCollected == coinsInLevel)
                {
                coinsCollectedText.color = Color.green;
                finishText = "You have collected ALL the coins and finished the level! Congratulations!";
                }
            else
                {
                coinsCollectedText.color = Color.yellow;
                finishText = "You have collected all the required coins and finished the level!";
                }
            }
        else
            {
            finishText = "You have not collected all the required coins. You have " + (coinsInLevel - coinsCollected).ToString() + "/" + coinsInLevel.ToString() + " coins left.";
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


    void OnDisable()
        {
        if (tutorialLevel)
            {
            BallController.OnCoinPickup -= OnCoinPickedUp;
            BallController.OnReachFinish -= ReachedFinish;
            }
        else
            {
            BallController.OnCoinPickup -= OnCoinPickedUp;
            BallController.OnLifeLost -= OnLifeLost;
            BallController.OnGameOver -= GameOver;
            BallController.OnReachFinish -= ReachedFinish;
            }
        }
    }
