using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    /// <summary>
    /// 플레이어 인풋 액션
    /// </summary>
    PlayerInputActions playerInputActions;

    /// <summary>
    /// 공의 속도 벡터
    /// </summary>
    public Vector2 velocity;

    /// <summary>
    /// 공의 이동 속도
    /// </summary>
    public float speed = 5f;        // 공의 이동 속도

    /// <summary>
    /// 공의 레이캐스트 길이(공의 반지름보다 약간 커야 함)
    /// </summary>
    public float rayLength = 0.6f;

    /// <summary>
    /// 벽과의 충돌로 벽을 파괴하라고 알리는 델리게이트(충돌한 자식 벽돌 전달)
    /// </summary>
    public Action<GameObject> onBrickDestroy;

    /// <summary>
    /// 공을 처음에 한 번만 컨트롤 할 수 있게
    /// </summary>
    bool isStart = true;

    /// <summary>
    /// 벽돌 클래스
    /// </summary>
    Brick brick;

    /// <summary>
    /// 플레이어
    /// </summary>
    Player player;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void Start()
    {
        brick = FindAnyObjectByType<Brick>();
        player = FindAnyObjectByType<Player>();
    }

    private void OnEnable()
    {
        playerInputActions.StartBall.Enable();
        playerInputActions.StartBall.Space.performed += OnSpace;
    }

    private void OnDisable()
    {
        playerInputActions.StartBall.Space.performed -= OnSpace;
        playerInputActions.StartBall.Disable();
    }

    /// <summary>
    /// 처음 공이 움직이기 위해 스페이스바와 연결된 함수
    /// </summary>
    /// <param name="context"></param>
    private void OnSpace(InputAction.CallbackContext context)
    {
        if (isStart)
        {
            Debug.Log("스페이스바 누름");
            float randomXNumber = UnityEngine.Random.Range(0.3f, 1f);
            float randomYNumber = UnityEngine.Random.Range(0.3f, 1f);
            velocity = new Vector2(randomXNumber, randomYNumber);     // 랜덤한 방향으로 설정
            isStart = false;
        }
    }

    void Update()
    {
        if (isStart)
        {
            // 스페이스바를 누르기 전까지는 플레이어와 함께 움직이게
            if (player != null)
            {
                // 공의 위치를 플레이어 x 위치에 맞춤
                transform.position = new Vector2(player.transform.position.x, transform.position.y);
            }
        }
        else
        {
            // 공의 이동
            transform.position += (Vector3)velocity * speed * Time.deltaTime;

            // 공의 진행 방향으로 레이캐스트를 쏴서 충돌 확인
            CheckCollisionWithBricks();
        }

    }

    /// <summary>
    /// 레이캐스트로 충돌을 확인하고 velocity 을 튕기는 함수
    /// </summary>
    void CheckCollisionWithBricks()
    {
        // 공의 현재 위치에서 진행 방향으로 레이캐스트 발사
        RaycastHit2D hit = Physics2D.Raycast(transform.position, velocity.normalized, rayLength);

        if (hit.collider != null)
        {
            // 벽돌과 충돌한 경우, 태그로 벽돌인지 확인
            if (hit.collider.CompareTag("Brick"))
            {
                Debug.Log("벽돌과 충돌");

                // 충돌한 벽돌의 이름 출력
                Debug.Log($"충돌한 벽돌 이름 : {hit.collider.name}");

                Debug.Log($"충돌 전 velocity : {velocity}");
                velocity.y = -velocity.y;       // 공의 진행 방향 반전 (y축)
                Debug.Log($"충돌 후 velocity : {velocity}");

                GameObject collidedBrick = hit.collider.gameObject;     // 충돌한 자식 벽돌
                onBrickDestroy?.Invoke(collidedBrick);                  // 벽을 파괴하라고 알림
            }

            // 플레이어와 충돌한 경우
            else if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("플레이어와 충돌");
                
                velocity.y = -velocity.y;       // 공의 진행 방향 반전 (y축)
            }

            // 왼쪽, 오른쪽 벽과 충돌한 경우
            else if (hit.collider.CompareTag("LRBorder"))
            {
                Debug.Log("LR벽과 충돌");
                Debug.Log($"충돌 전 velocity : {velocity}");
                velocity.x = -velocity.x;       // 공의 진행 방향 반전 (x축)
                Debug.Log($"충돌 후 velocity : {velocity}");
            }

            // 위쪽 벽과 충돌한 경우
            else if (hit.collider.CompareTag("UpBorder"))
            {
                Debug.Log("Up벽과 충돌");
                Debug.Log($"충돌 전 velocity : {velocity}");
                velocity.y = -velocity.y;       // 공의 진행 방향 반전 (y축)
                Debug.Log($"충돌 후 velocity : {velocity}");
            }

            // 아래쪽 벽과 충돌한 경우
            else if (hit.collider.CompareTag("DownBorder"))
            {
                Debug.Log("게임 오버");
            }
        }
    }
}
