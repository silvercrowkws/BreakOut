using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Brick : MonoBehaviour
{
    /// <summary>
    /// 모든 Ball의 배열
    /// </summary>
    private List<Ball> balls = new List<Ball>();

    /// <summary>
    /// 공 클래스
    /// </summary>
    Ball ball;

    /// <summary>
    /// 아이템 프리팹
    /// </summary>
    public GameObject ItemPrefabs;

    /// <summary>
    /// 공을 늘리는 아이템 클래스
    /// </summary>
    IncreaseBall increaseBall;

    private void Awake()
    {
        
    }

    private void Start()
    {
        //increaseBall = ItemPrefabs.GetComponent<IncreaseBall>();
        //increaseBall.onBallIncrease += OnBallIncrease;

        // IncreaseBall 객체를 찾고 onBallIncrease 이벤트에 메서드 등록
        //increaseBall = FindObjectOfType<IncreaseBall>();
        increaseBall = ItemPrefabs.GetComponent<IncreaseBall>();
        if (increaseBall != null)
        {
            increaseBall.onBallIncrease += OnBallIncrease;
            Debug.Log("찾음");
        }
        else
        {
            Debug.LogError("IncreaseBall 객체를 찾을 수 없습니다.");
        }

        InitializeBalls();
    }

    /// <summary>
    /// 모든 Ball 객체 초기화
    /// </summary>
    private void InitializeBalls()
    {
        balls.Clear(); // 기존 리스트를 비우고
        balls.AddRange(FindObjectsOfType<Ball>()); // 새로운 Ball 객체들을 추가

        foreach (var ball in balls)
        {
            Debug.Log($"찾은 공: {ball.name}");
            ball.onBrickDestroy += OnBrickDestroy;
        }
    }

    /// <summary>
    /// 아이템 충돌로 생성된 공을 찾는 함수
    /// </summary>
    public void OnBallIncrease()
    {
        InitializeBalls();
    }

    /// <summary>
    /// 공과 충돌한 벽돌을 파괴하는 함수
    /// </summary>
    /// <param name="brickChild">파괴할 벽돌</param>
    private void OnBrickDestroy(GameObject brickChild)
    {
        // 10% 확률로 파괴되는 자식의 위치에 아이템 생성
        if (UnityEngine.Random.Range(0f, 1f) < 0.1f)
        {
            Debug.Log("아이템 생성");
            //Instantiate(ItemPrefabs, brickChild.transform);
            Instantiate(ItemPrefabs, brickChild.transform.position, Quaternion.identity);
        }

        Destroy(brickChild);        // 자식 벽돌 파괴
    }
}
