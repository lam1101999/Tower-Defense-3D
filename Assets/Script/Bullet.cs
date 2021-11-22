
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
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

        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
