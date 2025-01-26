using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public LayerMask enemyMask;

    [Header("Attributes")]
    public int damage;
    [SerializeField] private float bulletSpeed = 5f;

    private Transform target;
    private Rigidbody2D rb;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    private void Start()
    {
        Destroy(gameObject, 5f);
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * bulletSpeed;

        float angle = Mathf.Atan2(target.position.y - transform.position.y,
            target.position.x - transform.position.x) * Mathf.Rad2Deg + -90f;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = targetRotation;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Creature enemy = collision.gameObject.GetComponent<Creature>();

        enemy.gameObject.GetComponent<Health>().TakeDamage(damage);
        
        Destroy(gameObject);
    }
}
