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
    Ball[] balls;

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
        increaseBall = ItemPrefabs.GetComponent<IncreaseBall>();
        increaseBall.onBallIncrease += OnBallIncrease;

        // 모든 Ball 객체를 배열로 가져오기
        balls = FindObjectsOfType<Ball>();

        // 배열 출력
        foreach (var ball in balls)
        {
            Debug.Log($"찾은 공: {ball.name}");
            ball.onBrickDestroy += OnBrickDestroy;
        }
    }

    /// <summary>
    /// 아이템 충돌로 생성된 공을 찾는 함수
    /// </summary>
    private void OnBallIncrease()
    {
        // 모든 Ball 객체를 배열로 가져오기
        balls = FindObjectsOfType<Ball>();

        // 배열 출력
        foreach (var ball in balls)
        {
            Debug.Log($"찾은 공: {ball.name}");
            ball.onBrickDestroy += OnBrickDestroy;
        }
    }

    /// <summary>
    /// 공과 충돌한 벽돌을 파괴하는 함수
    /// </summary>
    /// <param name="brickChild">파괴할 벽돌</param>
    private void OnBrickDestroy(GameObject brickChild)
    {
        // 10% 확률로 파괴되는 자식의 위치에 아이템 생성
        if (UnityEngine.Random.Range(0f, 1f) < 0.9f)
        {
            Debug.Log("아이템 생성");
            //Instantiate(ItemPrefabs, brickChild.transform);
            Instantiate(ItemPrefabs, brickChild.transform.position, Quaternion.identity);
        }

        Destroy(brickChild);        // 자식 벽돌 파괴
    }
}
