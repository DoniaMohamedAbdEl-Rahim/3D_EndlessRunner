using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 10f;
    void Update()
    {
        this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
