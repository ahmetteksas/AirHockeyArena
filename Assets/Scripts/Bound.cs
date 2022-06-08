using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    public Transform vektorback;
    public Transform vektorforward;

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.z = Mathf.Clamp(viewPos.z, vektorback.transform.position.z, vektorforward.transform.position.z);
        transform.position = viewPos;
    }
}
