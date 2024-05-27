using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBallText : MonoBehaviour
{
    public Transform ballParent; // 공들의 부모 오브젝트

    void Start()
    {
        int textCount = PlayerPrefs.GetInt("TextCount", 0);

        // 부모 오브젝트 아래에 있는 모든 공을 배열로 가져오기
        GameObject[] ballPlayers = new GameObject[ballParent.childCount];
        for (int i = 0; i < ballParent.childCount; i++)
        {
            ballPlayers[i] = ballParent.GetChild(i).gameObject;
        }

        for (int i = 0; i < textCount; i++)
        {
            string passedText = PlayerPrefs.GetString("PassedText" + i, "기본값");

            // 각 공에 텍스트 할당
            if (i < ballPlayers.Length)
            {
                Text ballTextComponent = ballPlayers[i].GetComponentInChildren<Text>();
                if (ballTextComponent != null)
                {
                    ballTextComponent.text = passedText;
                }
            }
        }
    }
}
