using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float ScreenWidthInUnits, MinScreenXPos, MaxScreenXPos;
    private GameSession gameSession;
    private Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    { 
        //float MousePosInUnits = Input.mousePosition.x / Screen.width * ScreenWidthInUnits; Moved to GetXPos
        Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);
        PaddlePos.x = Mathf.Clamp(GetXPos(), MinScreenXPos, MaxScreenXPos);
        transform.position = PaddlePos;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits; ;
        }
        
    }
}
