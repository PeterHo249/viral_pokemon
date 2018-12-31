using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftRight : MonoBehaviour
{
    public float speed = 10f, maxspeed = 5, change = 20f;
    bool faceRight = true;
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
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        if (Input.GetKey(KeyCode.RightArrow))
        { 
            r2.AddForce(Vector2.right * change);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            r2.AddForce(Vector2.left * change);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (h > 0 && !faceRight)
            Flip();
        if (h < 0 && faceRight)
            Flip();

        r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);

    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
