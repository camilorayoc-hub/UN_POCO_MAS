using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 move;

    void Awake() { rb = GetComponent<Rigidbody2D>(); }

    void Update()
    {
        float h = Input.GetAxisRaw(""Horizontal"");
        float v = Input.GetAxisRaw(""Vertical"");
        move = new Vector2(h, v).normalized * speed;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved)
            {
                Vector3 world = Camera.main.ScreenToWorldPoint(t.position);
                Vector2 dir = (world - transform.position);
                move = dir.normalized * speed;
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = move;
    }
}
