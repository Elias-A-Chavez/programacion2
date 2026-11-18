using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeEnemy : Enemies, IDamageable
{
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject attackPower;
    public static int enemiesKilled = 0;
    float timer;

    protected override void Start()
    {
        base.Start();

        if (enemiesKilled >= 5)
        {
            enemiesKilled = 0;
        }

        
    }


    protected override void Update()
    {

        base.Update();

        timer += Time.deltaTime;
        if (timer > 2)
        {
            Attack();
            timer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("IceAttack"))
        {
            enemiesKilled++;

        }
    }

    private void Attack()

    {
        Instantiate(attackPower, attackPoint.transform.position, attackPoint.transform.rotation);
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
  