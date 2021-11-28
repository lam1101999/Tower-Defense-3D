
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float turningSpeed = 10;
    [Header("Unity Setup")]
    public int damage = 5;
    public float explosionRadius = 0;
    public float speed = 15f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        AimTarget();
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

    }
    private void HitTarget()
    {
        GameObject EffectInstant = Instantiate(impactEffect, transform.position, transform.rotation) as GameObject;
        Destroy(EffectInstant, 2);

        if (explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    private void Damage(Transform target)
    {
        Enemy enemy= target.GetComponent<Enemy>();
        enemy.TakeDame(damage);
    }
    private void AimTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Quaternion rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turningSpeed);
        transform.rotation = rotation;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
