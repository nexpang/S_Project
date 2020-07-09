using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private Vector2 targetPosition = Vector2.zero;

    private float currentPositionX = 0f;
    private float targetPositionX = 0f;

    private Camera cam = null;
    private float halfWidth = 0f;
    private float halfHeight = 0f;

    private float xMin = 0f;
    private float xMax = 0f;
    void Start()
    {
        // 맵 영역 제한
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        xMin = GameManager.Instance.limitMinX + width / 2;
        xMax = GameManager.Instance.limitMaxX - width / 2;
    }
    void Update()
    {
        currentPositionX = transform.localPosition.x;

        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPositionX = targetPosition.x;
        
        if (currentPositionX - 3.5f > targetPositionX || currentPositionX + 3.5f < targetPositionX)
        {
            if (targetPosition.y > -3f)
            {
                targetPositionX = Mathf.Clamp(targetPositionX, xMin, xMax);
                transform.DOMoveX(targetPositionX, 1f);
            }
        }
    }
}
