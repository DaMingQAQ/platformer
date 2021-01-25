using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float lerpIndex = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Vector2.Lerp(transform.position, target.position, lerpIndex);
        Vector3 pos3 = pos;
        pos3.z = -10;
        transform.position = pos3;
    }
}
