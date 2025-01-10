using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBall : MonoBehaviour
{
    // 1. 계속해서 아래로 이동한다v
    // 2. 레이캐스트로 플레이어와의 충돌을 감지한다.v
    // 3. 플레이어와 충돌하면 공을 하나 늘린다.
    // 3.1 공을 늘릴때는 현재 플레이어의 위치에서?
    // 3.2 공을 늘리고 Brick에게 알려서 공을 찾게 한다
    // 4. 플레이어와 충돌 or DownBorder와 충돌한 경우 파괴

    /// <summary>
    /// 아이템의 이동속도
    /// </summary>
    float itemSpeed = 2.0f;

    /// <summary>
    /// 아이템의 레이캐스트 길이
    /// </summary>
    public float rayLength = 0.8f;

    /// <summary>
    /// 아이템이 충돌했을 때 공을 늘리라고 알리는 델리게이트
    /// </summary>
    public Action onBallIncrease;

    /// <summary>
    /// 플레이어
    /// </summary>
    Player player;

    /// <summary>
    /// 공의 프리팹
    /// </summary>
    public GameObject ballPrefabs;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        // 아이템을 계속 아래로 이동
        transform.position = new Vector3(transform.position.x, transform.position.y - itemSpeed * Time.deltaTime, transform.position.z);

        // 플레이어와의 충돌을 레이캐스트로 감지
        CheckCollisionWithPlayers();
    }

    /// <summary>
    /// 플레이어와의 충돌을 감지하는 함수
    /// </summary>
    void CheckCollisionWithPlayers()
    {
        // 현재 아이템의 위치에서 아래쪽으로 레이캐스트를 쏴서 플레이어와 충돌 여부 확인
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength);

        if (hit.collider != null)
        {
            // 플레이어와 충돌한 경우
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("아이템과 플레이어가 충돌");

                // 현재 플레이어의 위치에 공 하나 생성
                Instantiate(ballPrefabs, new Vector3(player.transform.position.x, -3.9f, 0f), Quaternion.identity);

                // 공을 하나 늘리고 벽돌에게 공을 찾게 하는 함수
                onBallIncrease?.Invoke();

                // 자신을 파괴
                Destroy(gameObject);
            }
            else if (hit.collider.CompareTag("DownBorder"))
            {
                // 자신을 파괴
                Destroy(gameObject);
            }
        }
    }
}
