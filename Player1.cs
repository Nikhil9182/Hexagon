using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public float moveSpeed = 600f;
    float movement = 0f;
    private float screenWidth;
    public void Start()
    {
        screenWidth = Screen.width;
    }
    // Update is called once per frame
    void Update()
    {

        int i = 0;
        while (i < Input.touchCount) 
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began )//&& touch.phase != TouchPhase.Ended )
            {
                if (touch.position.x > screenWidth / 2)
                {
                    //move right
                    movement = 1f;
                }
                else if (touch.position.x < screenWidth / 2)
                {
                    movement = -1f;
                }
                
            }
        }
    }
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
