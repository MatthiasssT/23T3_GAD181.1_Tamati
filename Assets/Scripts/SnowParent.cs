using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowParent : MonoBehaviour
{
    
    // Reference to the parent object (Snow Objects)
    public Transform parentObject;

    // Check if time is frozen
    private bool isTimeFrozen = false;
    public float destroyDelay = 1.0f;
    public GameObject youWin;
    public KeyCode quitKey = KeyCode.Escape;

    // Update is called once per frame
    void Update()
    {
        // Check if the parent object has no children
        if (parentObject.childCount == 0 && !isTimeFrozen)
        {
            // Set the time scale to 0 (pause the game)
            StartCoroutine(YouWin());
            isTimeFrozen = true;
            
        }
        else if (parentObject.childCount > 0 && isTimeFrozen)
        {
            // Unpause the game by resetting the time scale to 1
            Time.timeScale = 1f;
            isTimeFrozen = false;
        }

        if (Input.GetKeyDown(quitKey))
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }

    IEnumerator YouWin()
    {
        yield return new WaitForSeconds(destroyDelay);
        Debug.Log("You Win");
        Time.timeScale = 0f;
        youWin.SetActive(true);
    }
}
