using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    public Paddle Paddle1;
    public float XDirec, YDirec;
    public AudioClip[] BallSounds;

    private Boolean NotStarted = true;
    private Vector2 PaddleToBallVector;
    private AudioSource MyAudioSource;
    Rigidbody2D myRigidBody2D;
    [SerializeField] float randomFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        PaddleToBallVector = this.transform.position - Paddle1.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NotStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
            MyAudioSource = GetComponent<AudioSource>();
        }
        //Debug.Log(GetComponent<Rigidbody2D>().position);
    }
    
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NotStarted = false;
            myRigidBody2D.velocity = new Vector2 (XDirec, YDirec);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 PaddlePos = new Vector2(Paddle1.transform.position.x, Paddle1.transform.position.y);
        transform.position = PaddlePos + PaddleToBallVector;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!NotStarted)
        {
            Vector2 velocityTweak = new Vector2(GenRandomFloat(),GenRandomFloat());
            AudioClip clip = BallSounds[UnityEngine.Random.Range(0,BallSounds.Length)];
            //Debug.Log(clip.name);
            MyAudioSource.PlayOneShot(clip);
            myRigidBody2D.AddForce(velocityTweak);
        }
    }

    private float GenRandomFloat()
    {
        return UnityEngine.Random.Range(1f, randomFactor);
    }


}
