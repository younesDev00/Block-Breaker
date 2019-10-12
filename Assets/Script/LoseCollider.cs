using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D Collusion)
    {
        //int scene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(scene + 1);  
        SceneManager.LoadScene("GameOver");
        
    }

   
}
