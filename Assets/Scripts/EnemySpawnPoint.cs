using System;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private BeeEnemy enemy;
    [SerializeField] private GameObject spawnPoint;
    private float timer;
    ObjectPool<BeeEnemy> pool;

    void Start()
    {
        pool = new ObjectPool<BeeEnemy>(CreateEnemy, ActivateEnemy, DeactivateEnemy, DestroyEnemy, false, 10, 20);
    }

    private void DestroyEnemy(BeeEnemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void DeactivateEnemy(BeeEnemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void ActivateEnemy(BeeEnemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private BeeEnemy CreateEnemy()
    {
        BeeEnemy newEnemy = Instantiate(enemy);
        newEnemy.pool = pool;
        return newEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 6)
        {
            BeeEnemy newEnemy = pool.Get();
            newEnemy.transform.position = spawnPoint.transform.position;
            timer = 0;
        }
        
    }
}
