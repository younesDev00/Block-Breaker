using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //public GameObject BlockParent; old method
    [SerializeField] int NumOfBlocks;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameSession gameStatus;
    
    private void Start()
     {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameSession>();
    }

    public void CountBlocks()
    {
         NumOfBlocks += 1; //BlockParent.transform.childCount; old method
    }

    public void DestroyBlocks()
    {
        NumOfBlocks -= 1;
        //Debug.Log(gameStatus);
        IncreaseScore();
        if (NumOfBlocks == 0)
        {
            nextLevel();
        }
    }

    public void IncreaseScore()
    {
        gameStatus.AddToScore();
    }

    private void nextLevel()
    {
        sceneLoader.LoadNextScene();
    }
}
