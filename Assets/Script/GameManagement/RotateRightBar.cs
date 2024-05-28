using UnityEngine;

public class RotateRightBar : MonoBehaviour
{
    public float maxRotation = 290.0f; // 최대 회전 값
    public float rotationSpeed = 80.0f; // 회전 속도 (초당 회전 각도)
    private float originalRotation; // 초기 회전 값
    public bool isRotating = false; // 회전 중인지 여부

    void Start()
    {
        originalRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isRotating = true;
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            isRotating = false;
        }
    }

    void FixedUpdate()
    {
        // M 키가 눌린 상태에서 회전합니다.
        if (isRotating)
        {
            // 부드럽게 회전하기 위해 보간을 사용합니다.
            float targetRotation = maxRotation;
            float currentRotation = transform.eulerAngles.z;

            float newRotation = Mathf.MoveTowardsAngle(currentRotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            // 회전을 적용합니다.
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, newRotation);
        }
        else
        {
            // M 키가 눌리지 않은 상태에서 회전값을 초기 값으로 되돌립니다.
            float currentRotation = transform.eulerAngles.z;
            float newRotation = Mathf.MoveTowardsAngle(currentRotation, originalRotation, rotationSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, newRotation);
        }
    }

}

