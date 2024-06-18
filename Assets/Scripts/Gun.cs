using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
 
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float bulletSpeed = 10f;
    

    private void Update()
    { 
        
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();   
        }
    }

    private void Fire()
    {
        GameObject bullet = ObjectPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * bulletSpeed;
    }
}

