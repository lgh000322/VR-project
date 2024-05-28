using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public Transform playerParent;

    Transform TransformlowestPlayer(Transform parent)
    {
        Transform lowestPlayer = null;
        float lowestY = float.MaxValue;

        foreach (Transform child in parent)
        {
            float playerY = child.position.y;

            if (playerY < lowestY)
            {
                lowestPlayer = child;
                lowestY = playerY;
            }
        }

        return lowestPlayer;
    }

    void Update()
    {

        Transform lowestPlayer = TransformlowestPlayer(playerParent);
        if(playerParent.transform.childCount==1)
        {
            Transform lastPlayer = playerParent.GetChild(0);
            Vector3 targetPosition = new Vector3(lastPlayer.position.x, lastPlayer.position.y, transform.position.z);
            transform.position = targetPosition;
        }

        if (lowestPlayer != null)
        {
            Vector3 targetPosition = new Vector3(lowestPlayer.position.x, lowestPlayer.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        }
    }
}
