using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float PlayerMoveSpeed = 5f;

    public int Score = 0;

    public TextMeshProUGUI ScoreText;

    [SerializeField] Sprite spriteUp;
    [SerializeField] Sprite spriteDown;
    [SerializeField] Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    Vector2 input;
    Vector2 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        velocity = input.normalized * PlayerMoveSpeed;

        if(input.sqrMagnitude > 0.01f)
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                if(input.x > 0)
                    sr.flipX = false;
                else
                    sr.flipX = false;
            }
            else
            {
                if(input.y > 0)
                {
                    sr.sprite = spriteUp;
                }
                else
                {
                    sr.sprite = spriteDown;
                }
            }
        }

        ScoreText.text = "Score: " + Score.ToString("D4");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (input.x > 0)
        {
            sr.sprite = spriteRight;
        }
        else if (input.x < 0)
        {
            sr.sprite = spriteLeft;
        }
        else if (input.y > 0)
        {
            sr.sprite = spriteUp;
        }
        else if (input.y < 0)
        {
            sr.sprite = spriteDown;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Score += collision.GetComponent<ItemObj>().GetPoint();
            Destroy(collision.gameObject);
        }
    }
}
