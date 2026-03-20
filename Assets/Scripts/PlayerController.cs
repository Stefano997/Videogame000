using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastDirection;

    private ItemWorld currentItem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        rb.interpolation = RigidbodyInterpolation2D.Interpolate; // Per Pixel Perfect Camera
    }

    void Update()
    {
        // input
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
        movement = input.normalized; // normalizzare per blend tree?

        // update variabili animator di movimento
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // update variabili animatori di ultima direzione
        if (movement.sqrMagnitude > 0.1f)
        {
            lastDirection = movement; // update ultima direzione che posso anche usare altrove

            animator.SetFloat("LastMoveX", lastDirection.x);
            animator.SetFloat("LastMoveY", lastDirection.y);
        }

        if (Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            currentItem.Collect();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed; // movimento diagonale aggiustato
        /*
        Vector2 pos = rb.position;
        float pixelsPerUnit = 16f;

        pos.x = Mathf.Round(pos.x * pixelsPerUnit) / pixelsPerUnit;
        pos.y = Mathf.Round(pos.y * pixelsPerUnit) / pixelsPerUnit;

        rb.MovePosition(pos + movement * moveSpeed * Time.fixedDeltaTime);
        */
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld item = collision.GetComponent<ItemWorld>();

        if (item != null)
        {
            currentItem = item;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        ItemWorld item = collision.GetComponent<ItemWorld>();

        if (item != null && item == currentItem)
        {
            currentItem = null;
        }
    }
}