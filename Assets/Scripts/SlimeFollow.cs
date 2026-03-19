using UnityEngine;

public class SlimeFollow : MonoBehaviour
{
    public Transform player; // player da seguire

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;


    public float normalSpeed = 5f;
    public float minSpeed = 3.5f; // quando vicino
    public float maxSpeed = 7f; // quando lontano

    public float stopDistance = 2f;
    public float resumeDistance = 3f;
    public float slowSpeedDistance = 3f; // distanza sotto la quale andare piano
    public float maxSpeedDistance = 4f; // distanza per cui correre

    private bool isFollowing = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.position);

        // flippa lo sprite a destra/sinistra
        if (direction.x < -0.1f)
            sprite.flipX = true;
        else if (direction.x > 0.1f)
            sprite.flipX = false;

        // check se seguire oppure no
        if (isFollowing && distance < stopDistance)
            isFollowing = false;
        if (!isFollowing && distance > resumeDistance)
            isFollowing = true;

        // regola velocità
        if (isFollowing)
        {
            float currentSpeed = normalSpeed;

            //animator.SetFloat("MoveX", direction.x);
            //animator.SetFloat("MoveY", direction.y);
            animator.SetFloat("Speed", rb.velocity.sqrMagnitude);

            // se è lontano -> accelera
            if (distance > maxSpeedDistance) currentSpeed = maxSpeed;

            // se è vicino -> rallenta
            if (distance < slowSpeedDistance) currentSpeed = minSpeed;

            rb.velocity = direction * currentSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
        }
    }
}