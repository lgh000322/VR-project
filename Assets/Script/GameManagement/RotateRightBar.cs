using UnityEngine;

public class RotateRightBar : MonoBehaviour
{
    public float maxRotation = 290.0f; // 최대 회전 값
    public float rotationSpeed = -80.0f; // 회전 속도 (초당 회전 각도)
    private float originalRotation; // 초기 회전 값
    private bool isRotating = false; // 회전 중인지 여부

    void Start()
    {
        originalRotation = transform.eulerAngles.z;
        Debug.Log("orginalRotation= " + originalRotation);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isRotating = true;
        }

        // m 키가 눌린 상태에서 회전합니다.
        if (isRotating)
        {
            // 부드럽게 회전하기 위해 보간을 사용합니다.
            float targetRotation = maxRotation;
            float currentRotation = transform.eulerAngles.z;
            float newRotation = Mathf.MoveTowards(
                currentRotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            Debug.Log("KeyDown: newRotation= " + newRotation);

            // 회전을 적용합니다.
            transform.rotation = Quaternion.Euler(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                newRotation
            );

        }
        else
        {
            // m 키가 눌리지 않은 상태에서 회전값을 초기 값으로 되돌립니다.
            float currentRotation = transform.eulerAngles.z;
            float newRotation = Mathf.MoveTowards(
                currentRotation,
                originalRotation,
                rotationSpeed * Time.deltaTime
            );

            Debug.Log("KeyUp: newRotation= " + newRotation);

            transform.rotation = Quaternion.Euler(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                newRotation
            );
        }
    }
}
