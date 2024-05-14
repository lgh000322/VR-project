using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartOpt : MonoBehaviour
{
    public void LoadOptScene()
    {
        Debug.Log("옵션버튼 클릭");
        SceneManager.LoadScene("Option");
    }
}
