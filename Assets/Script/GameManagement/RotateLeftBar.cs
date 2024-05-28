using UnityEngine;

public class RotateLeftBar : MonoBehaviour
{
    public float maxRotation = 40f; // 최대 회전 값
    public float rotationSpeed = 80f; // 회전 속도 (초당 회전 각도)
    private float originalRotation; // 초기 회전 값
    public bool isRotating = false; // 회전 중인지 여부

    public float raycastDistance = 30.0f; // 레이캐스트 거리
    public LayerMask collisionLayer; // 충돌 감지 레이어

    void Start()
    {
        // 초기 회전 값을 저장합니다.
        originalRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        // Z 키가 눌리면 회전을 시작합니다.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isRotating = true;
        }

        // Z 키가 떼어지면 회전을 멈춥니다.
        if (Input.GetKeyUp(KeyCode.Z))
        {
            isRotating = false;
        }
    }

    void FixedUpdate()
    {
        // Z 키가 눌린 상태에서 회전합니다.
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
            // Z 키가 눌리지 않은 상태에서 회전값을 초기 값으로 되돌립니다.
            float currentRotation = transform.eulerAngles.z;
            float newRotation = Mathf.MoveTowardsAngle(currentRotation, originalRotation, rotationSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, newRotation);
        }

    }
}
