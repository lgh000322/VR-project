using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Text GameOverText;
    public GameObject parentObject;
    private bool isGameEnded = false;
    public GameObject ResultUI;

    void Update()
    {
        if (!isGameEnded && parentObject.transform.childCount == 1)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        GameObject remainingChild = parentObject.transform.GetChild(0).gameObject;
        Text ballTextComponent = remainingChild.GetComponentInChildren<Text>();  // 자식 객체에서 Text 컴포넌트를 가져옴
        if (ballTextComponent != null)
        {
            GameOverText.text = "걸린사람: " + ballTextComponent.text;
        }

        ResultUI.SetActive(true);
        isGameEnded = true;
        Time.timeScale = 0f;
    }
}
