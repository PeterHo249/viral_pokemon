using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f, maxspeed = 5, change = 20f;
    public bool up = false, down = false, left = false, right = false;

    public Rigidbody2D r2;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("Speed", Mathf.Abs(r2.velocity.y));
        if (Input.GetKey(KeyCode.UpArrow))
        {
            up = true; down = false; right = false;
            anim.SetBool("up", up);
            anim.SetBool("down", down);
            anim.SetBool("right", right);
            anim.SetFloat("Speed", Mathf.Abs(r2.velocity.y));

            if (up)
            {
                r2.AddForce(Vector2.up * change);
            }
        }

        //anim.SetFloat("Speed", Mathf.Abs(r2.velocity.y));
        if (Input.GetKey(KeyCode.DownArrow))
        {
            down = true; up = false; right = false;
            anim.SetBool("up", up);
            anim.SetBool("down", down);
            anim.SetBool("right", right);
            anim.SetFloat("Speed", Mathf.Abs(r2.velocity.y));
            if (down)
            {
                up = false; left = false; right = false;
                r2.AddForce(Vector2.down * change);
            }
        }

        //anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        if (Input.GetKey(KeyCode.RightArrow))
        {
            right = true; up = false; down = false;
            anim.SetBool("up", up);
            anim.SetBool("down", down);
            anim.SetBool("right", right);
            anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
            if (right)
            {
                up = false; down = false; left = false;
                r2.AddForce(Vector2.right * change);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            right = true; up = false; down = false;
            anim.SetBool("up", up);
            anim.SetBool("down", down);
            anim.SetBool("right", right);
            anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
            if (right)
            {
                up = false; down = false; left = false;
                r2.AddForce(Vector2.left * change);
            }
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        //r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetFloat("Speed", 0);
            r2.AddForce(Vector2.up * 0);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetFloat("Speed", 0);
            r2.AddForce(Vector2.down * 0);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetFloat("Speed", 0);
            r2.AddForce(Vector2.right * 0);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetFloat("Speed", 0);
            r2.AddForce(Vector2.left * 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (h > 0)
            {
                Vector3 scale;
                scale = transform.localScale;
                scale.x = 1;
                transform.localScale = scale;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (h < 0)
            {
                Vector3 scale;
                scale = transform.localScale;
                scale.x = -1;
                transform.localScale = scale;
            }
        }

        if (up || down || right)
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y * 0.7f);
    }
}
