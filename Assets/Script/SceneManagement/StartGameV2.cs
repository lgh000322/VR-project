using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StartGameV2 : MonoBehaviour
{
    public InputField[] inputFields;
    public GameObject specialTextObject; // 특정 텍스트의 부모 객체

    public void LoadGameScene()
    {
        string[] textsToPass = new string[8];
        bool hasEmptyText = false; // 빈 텍스트가 있는지 여부를 나타내는 변수

        for (int i = 0; i < 8; i++)
        {
            textsToPass[i] = inputFields[i].text;
            if (string.IsNullOrEmpty(textsToPass[i]))
            {
                Debug.Log("비어있는 값 발견.");
                hasEmptyText = true;
                break;
            }
        }

        // 하나라도 빈 텍스트가 있는 경우에만 처리
        if (hasEmptyText)
        {
            Debug.Log("토스트 띄워주는 메소드 실행.");
            // 특정 텍스트 활성화
            specialTextObject.SetActive(true);

            // 1초 후에 특정 텍스트 비활성화
            StartCoroutine(DisableSpecialTextAfterDelay(2.0f));
        }

        else
        {
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

    // 특정 텍스트를 일정 시간 후에 비활성화하는 코루틴
    private IEnumerator DisableSpecialTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        specialTextObject.SetActive(false);
    }
}
