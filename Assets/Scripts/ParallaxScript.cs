using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;

    private SpriteRenderer r;
    private float rHorizontalLength;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0);

        r = GetComponent<SpriteRenderer>();
        rHorizontalLength = r.bounds.size.x;
    }


    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(speed, 0);

        if (transform.position.x < -rHorizontalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(rHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
