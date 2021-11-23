
using UnityEngine;


public class Turret : MonoBehaviour
{
    private Transform target;
    private string enemyTag = "Enemy";
    private float fireCountDown;


    [Header("Attribute")]
    private float turningSpeed = 10f;
    public float range = 15f;
    public float fireRate = 1;
    [Header("Unity Setup")]
    public Transform rotatePart;

    public GameObject bulletPrefab;
    public Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        AimTarget();
        Shot();

    }
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance < range)
            target = nearestEnemy.transform;
        else target = null;
    }

    private void AimTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * turningSpeed).eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0, rotation.y, 0);
    }
    private void Shot()
    {
        if (fireCountDown <= 0f)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as GameObject;
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null)
            {
                bullet.Seek(target);
            }
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
