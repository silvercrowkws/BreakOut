using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 플레이어 인풋 액션
    /// </summary>
    PlayerInputActions playerInputActions;

    /// <summary>
    /// 플레이어의 입력값
    /// </summary>
    Vector2 moveInput;

    /// <summary>
    /// 플레이어가 움직이고 있는 중인지 알리는 bool 변수
    /// </summary>
    bool isMoving = false;

    /// <summary>
    /// 플레이어의 이동 속도
    /// </summary>
    public float moveSpeed = 10f;

    /// <summary>
    /// 플레이어의 x 위치 제한 범위
    /// </summary>
    public float xMin = -7.4f;
    public float xMax = 7.4f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Move.Enable();
        playerInputActions.Move.MoveAction.started += OnMoveStarted;
        playerInputActions.Move.MoveAction.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        playerInputActions.Move.MoveAction.canceled -= OnMoveCanceled;
        playerInputActions.Move.MoveAction.started -= OnMoveStarted;
        playerInputActions.Move.Disable();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isMoving)
        {
            // 이동 입력이 계속되는 동안 처리
            moveInput = playerInputActions.Move.MoveAction.ReadValue<Vector2>();

            // 이동 방향에 따른 위치 이동
            Vector2 moveDirection = moveInput.normalized * moveSpeed;

            // Transform을 이용하여 이동
            transform.Translate(moveDirection * Time.deltaTime);

            // 플레이어의 x 위치를 제한 범위 내로 클램프
            float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

            /*if (moveInput.x < 0)
            {
                Debug.Log("왼쪽");
            }
            else if (moveInput.x > 0)
            {
                Debug.Log("오른쪽");
            }*/
        }
    }

    /// <summary>
    /// 플레이어의 이동키가 눌러졌을 때 시작될 함수
    /// </summary>
    /// <param name="context"></param>
    private void OnMoveStarted(InputAction.CallbackContext context)
    {
        isMoving = true;
    }

    /// <summary>
    /// 플레이어의 이동키가 떨어졌을 때 시작될 함수
    /// </summary>
    /// <param name="context"></param>
    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        isMoving = false;
    }


}
