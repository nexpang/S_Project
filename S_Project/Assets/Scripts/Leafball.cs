using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leafball : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
