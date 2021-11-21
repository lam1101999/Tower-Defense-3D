using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 15f;
    public GameObject impactEffect;
    
    public void Seek(Transform _target){
    target = target;
    }
    
    void Update(){
    if(target == null){
    Destroy(gameObject);
    return;
    }
    
    Vector3 direction = target.position - transform.position;
    float distanceThisFrame = speed*time.deltaTime
    
    if(direction<=distanceThisFrame){
    HitTarget();
    return;
    }
    transform.Translate(direction.normalized*distanceThisFrame,Space.World);
   
    }
    private void HitTarget(){
    GameObject impactEffect = (GameObject)Instantiate(impactEffect,transform.position, transform.rotation);
    Destroy(impactEffect,2);
    
    Destroy(gameObject);
    Destroy(target.gameObject);
    }
}
