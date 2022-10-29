using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemy : MonoBehaviour
{
    EnemyGenerator _enemyG;
    Transform _spawnPos;
    void Start()
    {
        StartCoroutine(A());
    }
   IEnumerator A()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        _enemyG.EnemyDestroy(_spawnPos);
    }
    public void Set(EnemyGenerator eg, Transform t)
    {
        _enemyG = eg;
        _spawnPos = t;

    }
}
