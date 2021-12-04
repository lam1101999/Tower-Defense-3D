
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health;
    private Transform target;
    private int pathPointIndex = 0;
    [Header("Unity setup")]
    public int money = 15;
    public int startHealth = 10;
    public float speed = 10f;
    public GameObject deadEffect;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        target = PathPoints.points[pathPointIndex];

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            getNextPathPoint();
        }
    }

    void getNextPathPoint()
    {
        if (pathPointIndex >= PathPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        pathPointIndex++;
        target = PathPoints.points[pathPointIndex];
    }
    void EndPath()
    {
        PlayerStat.GetInstance().MinusHealth(1);
        Destroy(gameObject);
    }
    public void TakeDame(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {   
        GameObject effectInstante = Instantiate(deadEffect, transform.position, transform.rotation) as GameObject;
        Destroy(effectInstante, 2f);
        PlayerStat.GetInstance().AddCredit(money);
        Destroy(gameObject);
    }
}