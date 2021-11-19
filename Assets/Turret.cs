using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget",);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateTarget(){

    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
