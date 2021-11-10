using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public float speed  = 10f;
    private Transform target;
    private int pathPointIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        target = PathPoints.points[pathPointIndex];
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized*speed*Time.deltaTime, Space.World);
    }
}
