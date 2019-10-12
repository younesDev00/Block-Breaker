using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f , 10f)] [SerializeField] float timeSpeed = 1f;

    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 1;  
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    private void Awake()
    {
        MaintainScore();
    }

    private void Start() 
    {
        scoreText.SetText(currentScore.ToString());
    }

    void Update()
    {
        Time.timeScale = timeSpeed;
    }

    private void MaintainScore()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.SetText(currentScore.ToString());
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
