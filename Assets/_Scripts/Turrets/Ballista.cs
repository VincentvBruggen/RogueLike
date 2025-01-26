using UnityEngine;

public class Ballista : TurretBase
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    {
        anim.SetTrigger("Shoot");
        base.Shoot();
    }
}
