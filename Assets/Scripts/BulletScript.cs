using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
  private void OnEnable()
    {
        // Devuelve la bala al pool después de 2 segundos.
        Invoke("ReturnToPool", 2f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void ReturnToPool()
    {
        ObjectPool.Instance.ReturnBullet(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Esta parte sirve para manejar colisiones y devolver la bala al pool si colisiona con algo.
        ObjectPool.Instance.ReturnBullet(gameObject);
    }
}