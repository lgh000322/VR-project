﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
   public void QuitGames()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
