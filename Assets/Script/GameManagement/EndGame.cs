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
        Debug.Log("플레이어가 1개 남아 게임이 종료됩니다.");
        Time.timeScale = 0f;
    }
}
