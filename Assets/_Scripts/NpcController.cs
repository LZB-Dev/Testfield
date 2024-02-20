using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
