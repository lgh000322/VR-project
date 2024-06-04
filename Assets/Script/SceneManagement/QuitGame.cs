using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
   public void QuitGames()
    {
        Debug.Log("게임 종료");
        Application.Quit();

        // 에디터에서 실행 중일 때는 에디터를 종료합니다.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
