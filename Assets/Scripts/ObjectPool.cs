using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool Instance;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int poolSize = 5;

    private Queue<GameObject> objectPool;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        objectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            objectPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (objectPool.Count > 0)
        {
            GameObject bullet = objectPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(true);
            return bullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        objectPool.Enqueue(bullet);
    }
}

