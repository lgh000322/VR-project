using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToOpt : MonoBehaviour
{
    public void BackToOption()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Option");
    }
}
