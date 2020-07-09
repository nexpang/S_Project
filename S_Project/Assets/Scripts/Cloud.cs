using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private MeshRenderer meshRenderer = null;
    private Vector2 offset = Vector2.zero;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        offset.x += 0.1f * Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
