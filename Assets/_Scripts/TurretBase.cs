using UnityEngine;

public class TurretBase : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected Transform rotationPoint;
    [SerializeField] protected GameObject rangeVisual;
    [SerializeField] protected LayerMask enemyMask;

    [Header("Attributes")]
    public int damage = 15;
    public float radius = 2f;
    public float rotationSpeed = 20f;
    public float shootSpeed = 1f; // projectiles per second

    private Transform target;
    private float timeUntilFire;

    // Update is called once per frame
    protected virtual void Update()
    {
        if(target == null)
        {
            FindTarget();
            return;
        }
        if (!IsTargetInRange())
        {
            target = null;
            return;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            
            if(timeUntilFire >= 1f / shootSpeed)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }

        RotateToTarget();
    }
    protected virtual void Shoot()
    {
        GameObject projectileObj = Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
        Projectile projectileScript = projectileObj.GetComponent<Projectile>();

        if(projectileScript != null )
        {
            projectileScript.SetTarget(target);
            projectileScript.damage = damage;
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius,
            (Vector2)transform.position, 0f, enemyMask);

        if(hits.Length > 0 )
        {
            target = hits[0].transform;
            timeUntilFire = 1f;
        }
    }

    private bool IsTargetInRange()
    {
        if (Vector2.Distance(transform.position, target.position) < radius)
            return true;
        else
            return false;
    }

    private void RotateToTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, 
            target.position.x - transform.position.x) * Mathf.Rad2Deg + -90f;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        rotationPoint.rotation = Quaternion.RotateTowards(rotationPoint.rotation, targetRotation, 
            rotationSpeed * Time.deltaTime);
    }
    protected void OnMouseEnter()
    {
        rangeVisual.transform.localScale = Vector3.one * (radius * 2);
        rangeVisual.SetActive(true);
    }

    protected void OnMouseExit()
    {
        rangeVisual.SetActive(false);
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
