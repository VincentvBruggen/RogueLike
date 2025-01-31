using UnityEngine;

public class Creature : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField]
    private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        target = GameManager.instance.l_Path[pathIndex];
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        FindPath();
    }

    protected virtual void FixedUpdate()
    {
        // walk toward the target
        Vector2 direction = (target.position - transform.position).normalized;
        Debug.DrawRay(transform.position, direction);

        rb.linearVelocity = direction * moveSpeed;
    }

    // algorithm for finding the next path block to walk towards
    private void FindPath()
    {
        // if the creature is at its target position, move to the next path
        if(Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            pathIndex++;
            target = GameManager.instance.l_Path[pathIndex];

            // if path point equals the tower
            if (pathIndex == GameManager.instance.l_Path.Count)
            {
                // Damage the tower
                Destroy(gameObject);
                return;
            }
            else
            {
                target = GameManager.instance.l_Path[pathIndex];
            }
        }
    }
}
