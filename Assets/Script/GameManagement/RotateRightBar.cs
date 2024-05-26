using UnityEngine;

public class RotateRightBar : MonoBehaviour
{
    public float maxRotation = 290.0f; // 최대 회전 값
    public float rotationSpeed = 80.0f; // 회전 속도 (초당 회전 각도)
    private float originalRotation; // 초기 회전 값
    private bool isRotating = false; // 회전 중인지 여부

    void Start()
    {
        originalRotation = transform.eulerAngles.z;
        Debug.Log("Right=>originalRotation " + originalRotation);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isRotating = true;
        }

        // M 키가 눌린 상태에서 회전합니다.
        if (isRotating)
        {
            // 부드럽게 회전하기 위해 보간을 사용합니다.
            float targetRotation = maxRotation;
            float currentRotation = transform.eulerAngles.z;

            // 360도 범위를 넘어서 이동해야 할 경우에 Mathf.MoveToward 대신 Mathf.MoveTowardsAngle을 사용한다.
            // Mathf.MoveTowardsAngle은 목표로 하는 각도와 초기 각도의 차이를 계산한 후 짧은 방향으로 각도가 변한다.
            // 이 코드에서는 0에서 290으로 변하는데 짧은 각도가 음의 방향이기 때문에 정상적으로 로직이 실행된다.
            float newRotation = Mathf.MoveTowardsAngle(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 회전을 적용합니다.
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, newRotation);

            if (Input.GetKeyUp(KeyCode.M))
            {
                isRotating = false;
            }
        }
        else
        {
            // M 키가 눌리지 않은 상태에서 회전값을 초기 값으로 되돌립니다.
            float currentRotation = transform.eulerAngles.z;
            float newRotation = Mathf.MoveTowardsAngle(currentRotation, originalRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, newRotation);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;
            rb.velocity = pushDirection * rb.velocity.magnitude;
        }
    }
}
