using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        // flip sprite
        if (movement.x < 0)
            sprite.flipX = true;
        else if (movement.x > 0)
            sprite.flipX = false;
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed; // movimento diagonale aggiustato
    }
}