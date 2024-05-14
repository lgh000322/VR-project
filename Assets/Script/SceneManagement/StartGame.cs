using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
       public void LoadGameScene()
    {
        Debug.Log("게임 시작 버튼이 눌렸습니다.");
        SceneManager.LoadScene("Main");
    }
}
