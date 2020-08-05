using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private MeshRenderer meshRenderer = null;
    private Vector2 offset = Vector2.zero;


    private Vector2 currentPosition = Vector2.zero;
    private Vector2 targetPosition = Vector2.zero;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        currentPosition = transform.localPosition;

        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (currentPosition.x-30f >= targetPosition.x)
        {
            offset.x -= 0.1f * Time.deltaTime;
            meshRenderer.material.SetTextureOffset("_MainTex", offset);
        }
        else if (currentPosition.x+30f <= targetPosition.x)
        {
            offset.x += 0.1f * Time.deltaTime;
            meshRenderer.material.SetTextureOffset("_MainTex", offset);
        }
        else
        {
            meshRenderer.material.SetTextureOffset("_MainTex", offset);
        }
    }
}
