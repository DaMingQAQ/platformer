using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed =5;
    public float jumpForce = 1;
    bool isGround=true;
    public GameSceneUI gameUI;
    public AudioClip jumpSound;
    public AudioClip dieSound;
    public AudioClip punchSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Jump()
    {
        if (!isGround)
            return;
        isGround = false;
        jumpCd = 0.2f;
        GetComponent<AudioSource>().PlayOneShot(jumpSound);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce*100);
    }

    float jumpCd = 0;
    void GroundTest()
    {
        if(jumpCd>0)
        {
            jumpCd -= Time.deltaTime;
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f,1<<LayerMask.NameToLayer("Default"));
        if (hit.collider!=null)
        {
            isGround = true;
        }
            
    }


    // Update is called once per frame
    void Update()
    {
        GroundTest();
        if (Input.GetKey(KeyCode.W))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = ( (Vector2)transform.position+ Vector2.left * speed*Time.deltaTime*1000);
            GetComponent<SpriteRenderer>().flipX = true;
        }
         if (Input.GetKey(KeyCode.D))
        {
            transform.position=((Vector2)transform.position + Vector2.right * speed * Time.deltaTime * 1000);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy=collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            var dir = transform.position - enemy.transform.position;
            var angle=Vector3.Angle(dir.normalized, Vector3.up);
            if(angle<70)
            {
                Destroy(enemy.gameObject);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce * 50);
                GetComponent<AudioSource>().PlayOneShot(punchSound);
            }
            else
            {
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * 50 + dir.normalized * 50);
                Camera.main.GetComponent<CameraFollow>().enabled = false;
                gameUI.gameObject.SetActive(true);
                GetComponent<AudioSource>().PlayOneShot(dieSound);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Finish")
        {
            gameUI.Win();
            gameUI.gameObject.SetActive(true);
        }
    }

}
