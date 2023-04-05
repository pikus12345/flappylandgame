using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float xMovespeed;
    public float yMovespeed;
    public float JumpForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        Move(Input.GetAxisRaw("Horizontal") * Time.deltaTime * xMovespeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * yMovespeed);
    }
    public void Move(float hor, float ver)
    {
        rb.AddForce(new Vector2(hor, ver));
    }
    void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }
    private void OnBecameInvisible()
    {
        FindObjectOfType<GameManager>().RestartGame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject cb = collision.attachedRigidbody.gameObject;
        if (cb.CompareTag("FinishArea"))
        {
            FindObjectOfType<GameManager>().RestartGame();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject cb = collision.collider.gameObject;
        if (cb.GetComponent<LevelObject>())
        {
            if (cb.GetComponent<MovableObject>())
            {
                switch (cb.GetComponent<MovableObject>().Type)
                {
                    case MovableObjectType.Safe:
                        {
                            break;
                        }
                    case MovableObjectType.Unsafe:
                        {
                            FindObjectOfType<GameManager>().RestartGame();
                            break;
                        }
                }
            }
            if (cb.GetComponent<BonusObject>())
            {
                switch (cb.GetComponent<BonusObject>().Type)
                {
                    case BonusType.Increaser:
                        {
                            rb.mass += 0.1f;
                            transform.localScale *= 1.5f;
                            break;
                        }
                    case BonusType.Decreaser:
                        {
                            rb.mass -= 0.1f;
                            transform.localScale /= 1.5f;
                            break;
                        }
                }
                Destroy(cb);
            }
        }
    }
}
