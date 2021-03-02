
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickyScript : MonoBehaviour
{
    //On load, set canvas color and TMPro (Blue, "Instructions". Wait for player to click the Canvas element
    //On player click, change canvas color and TMPro (Red; "wait for green"). At random interval (min 1, max 5)
    //If player click is timely, change state of canvas color and TMPro (Green, "click now!")
    //Else if player click is too soon, change canvas color and TMPro (Blue; "Too soon!"). Restart game.
    //Start the timer in update function (var =+ Time.deltaTime)
    //On player click, change canvas color and TMPro(Blue, "Your time is: "), Display elapsed time.

    public Image canvasState;
    public TextMeshProUGUI uiText;


    private float waitTimer = 0;
    private bool waitTimerStarted;
    public float waitTimerMin = 1f;
    public float waitTimerMax = 5f;
    public bool gameOn = false;
    private Color currentState;

    //private bool timerState;
    private float elapsedTime;

    void Start()
    {
        currentState = Color.blue;
        canvasState.color = currentState;
        uiText.color = Color.white;
        uiText.text = "Instructions";
        waitTimer = Random.Range(waitTimerMin, waitTimerMax);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameOn = true;
            uiText.text = "Wait for it ...";
            currentState = Color.red;
        }
        canvasState.color = currentState;

        if (gameOn)
        {

            if (waitTimer > 0)
            {
                waitTimerStarted = true;
                waitTimer -= Time.deltaTime;
                Debug.Log("Timer: " + waitTimer);

                if (Input.GetKeyDown(KeyCode.Mouse0) && waitTimerStarted)
                {
                    currentState = Color.blue;
                    uiText.text = "WAIT FOR IT...";
                } else { }
            }
            else if (waitTimer <= 0)
            {
                currentState = Color.green;
                uiText.text = "Click!";
                Debug.Log("Click it!");
            }
                
            if (currentState == Color.green)
            {
                elapsedTime += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Your reaction time: " + elapsedTime);
                }
            }
        }
        
    }
}

/*
 * If GAMEON:
 *      canvas.color = "blue";
 *      
 *      if mouseDown:
 *          cavans.color = "red";
 *      if canvas.blue:
 *          text = "Message 1";
 *          textColor = "white";
 *          waitTimer = 3;
 *      if canvas.red:
 *          waitTimer -= 1;
 *          text = "Message 2";
 *      if canvas.green:
 * 
**/
