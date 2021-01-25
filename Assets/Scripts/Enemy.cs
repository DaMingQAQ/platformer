using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Turn()
    {
        fliped = !fliped;
    }

    bool fliped = false;
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, fliped? Vector3.left: Vector3.right, 0.1f, 1 << LayerMask.NameToLayer("Default"));
        if(hit.collider!=null)
        {
            Turn();
            return;
        }
        hit = Physics2D.Raycast(transform.position+( fliped ? Vector3.left : Vector3.right)*0.1f,Vector3.down , 0.1f, 1 << LayerMask.NameToLayer("Default"));
        if (hit.collider == null)
        {
            Turn();
            return;
        }
        transform.position = (transform.position + (fliped ? Vector3.left : Vector3.right) * speed/1000 * Time.deltaTime*50);
    }
}
