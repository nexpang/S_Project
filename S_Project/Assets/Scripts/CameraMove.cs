using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    private Vector2 targetPosition = Vector2.zero;

    private float currentPositionX = 0f;
    private float targetPositionX = 0f;

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
        if (targetPosition.y > -12f)
        {
            if (currentPositionX >= targetPositionX + 20f)
            {
               transform.DOMoveX(Mathf.Clamp(transform.position.x - 20, xMin, xMax), 1f);
            }else if (currentPositionX <= targetPositionX - 20f)
            {
                transform.DOMoveX(Mathf.Clamp(transform.position.x + 20, xMin, xMax), 1f);
            }
        }
    }
}
