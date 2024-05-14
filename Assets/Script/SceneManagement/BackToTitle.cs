using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToTitle : MonoBehaviour
{
    public void getBackToScene()
    {
        Debug.Log("옵션으로 돌아가는 버튼클릭");
        SceneManager.LoadScene("Title");
    }
}
