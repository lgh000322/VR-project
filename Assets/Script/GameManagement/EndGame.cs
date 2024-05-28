using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject parentObject;
    private bool isGameEnded = false;


    void Update()
    {
        if (!isGameEnded && parentObject.transform.childCount == 1)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        isGameEnded = true;
        Time.timeScale = 0f;
    }
}
