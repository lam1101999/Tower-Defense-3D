
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int pathPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(gameObject);
            return;
        }
        pathPointIndex++;
        target = PathPoints.points[pathPointIndex];
    }
}
