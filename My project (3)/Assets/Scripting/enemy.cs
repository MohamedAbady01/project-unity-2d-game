using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rg;
    SpriteRenderer sr;
    [SerializeField] private float speed = 350f;
    bool isright;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(rg.velocity.x)<=0.01f)
        {
            isright = !isright;
            sr.flipX = !sr.flipX;
        }
        if (isright)
        {
            rg.velocity = new Vector2(Time.fixedDeltaTime * speed, rg.velocity.y
                );
        }
        else
        {
            rg.velocity = new Vector2(Time.fixedDeltaTime * speed*-1, rg.velocity.y);
        }
    }
}
