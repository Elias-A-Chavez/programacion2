using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bossEnemy;
    [SerializeField] private int killsRequired = 5;

    private bool bossActivated = false;

    void Start()
    {
        
        if (bossEnemy != null)
        {
            bossEnemy.SetActive(false);
        }
        BeeEnemy.ResetKills();
    }

    void Update()
    {
        if (bossActivated || bossEnemy == null) return;

        if (BeeEnemy.EnemiesKilled >= killsRequired)
        {
            bossEnemy.SetActive(true);
            bossActivated = true;
           
        }
    }
}
