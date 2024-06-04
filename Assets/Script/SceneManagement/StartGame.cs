using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public InputField[] inputFields;

    public void LoadGameScene()
    {
        string[] textsToPass = new string[8];
        for (int i = 0; i < 8; i++)
        {
            textsToPass[i] = inputFields[i].text;
        }

        // 텍스트를 섞기
        textsToPass = ShuffleArray(textsToPass);

        // PlayerPrefs에 텍스트 저장
        for (int i = 0; i < textsToPass.Length; i++)
        {
            PlayerPrefs.SetString("PassedText" + i, textsToPass[i]);
            Debug.Log(textsToPass[i]);
        }

        PlayerPrefs.SetInt("TextCount", textsToPass.Length);
        SceneManager.LoadScene("Main");
    }

    private string[] ShuffleArray(string[] array)
    {
        System.Random rand = new System.Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        return array;
    }
}