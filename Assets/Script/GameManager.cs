using System;
using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager gameManager;
    private float gameSpeed = 5f;
    [SerializeField] private float speedIncrease = 0.15f;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 0;
    [SerializeField] private GameObject gameStart;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject buttonQuit;
    private bool isGameOver = false;
    private void Awake()
    {
        gameManager = this;

    }
    public float GetGameSpeed()
    {
        return gameSpeed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();


    }

    // Update is called once per frame
    void Update()
    {
        HandleStartGameInput(); 
       
        if (!isGameOver)
        {
            UpdateGameSpeed();
            UpdateScore();
        }
    }
    private void UpdateGameSpeed()
    {
        gameSpeed += Time.deltaTime * speedIncrease;
    }
    private void UpdateScore()
    {
        score += Time.deltaTime * 10;
        scoreText.text = "Score : " + Mathf.FloorToInt(score);
    }
    private void StartGame()
    {
        Time.timeScale = 0;
        score = 0;
        isGameOver = false;
        gameStart.SetActive(true);
        gameOver.SetActive(false);
        buttonQuit.SetActive(true);
    }
    private void HandleStartGameInput()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            gameStart.SetActive(false);
            gameOver.SetActive(false);
            buttonQuit.SetActive(false);
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOver.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(ReloadScene());
    }

    

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
