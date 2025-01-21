using UnityEngine;

public class Creature : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameManager.instance.a_Path[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        FindPath();
    }

    private void FixedUpdate()
    {
        // walk toward the target
        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * moveSpeed;
    }

    // algorithm for finding the next path block to walk towards
    private void FindPath()
    {
        // if the creature is at its target position, move to the next path
        if(Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            pathIndex++;
            target = GameManager.instance.a_Path[pathIndex];

            // if path point equals the tower
            if (pathIndex == GameManager.instance.a_Path.Length)
            {
                // Damage the tower
                Destroy(gameObject);
                return;
            }
            else
            {
                target = GameManager.instance.a_Path[pathIndex];
            }
        }
    }
}
