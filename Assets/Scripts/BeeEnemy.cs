using UnityEngine;
using UnityEngine.Pool;

public class BeeEnemy : Enemies, IDamageable
{
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject attackPower;
    public ObjectPool<BeeEnemy> pool;
    private static int enemiesKilled;
    public static int EnemiesKilled => enemiesKilled;
    public static void ResetKills() => enemiesKilled = 0;

    private float timer;
    private bool isReleased; 
    private void OnEnable()
    {
        isReleased = false;
        timer = 0f;
    }

    protected override void Update()
    {
        base.Update();

        timer += Time.deltaTime;
        if (timer > 2f)
        {
            Attack();
            timer = 0f;
        }
    }

    
    private void Attack()
    {
        Instantiate(attackPower, attackPoint.transform.position, attackPoint.transform.rotation);
    }

    public void TakeDamage()
    {
        if (isReleased) return;
        isReleased = true;

        enemiesKilled++;

        if (pool != null)
        {
            pool.Release(this);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
