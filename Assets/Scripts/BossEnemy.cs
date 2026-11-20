using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : Enemies, IDamageable
{
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject attackPower;
    [SerializeField] private int bossHealth;
    [SerializeField] private float paralyzeDuration;
    private bool isDead = false;
    private bool isParalyzed = false;
    private float timer;
    private int originalSpeed;

    protected override void Start()
    {
        base.Start();
        originalSpeed = speed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isDead || isParalyzed) return;
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
        if (isDead) return;
        if (collision.gameObject.CompareTag("Enemy")) return;

        if (collision.gameObject.CompareTag("IceAttack"))
        {

            TakeDamage();
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("SpecialAttack"))
        {

            TakeDamage();
            Paralize();
            Destroy(collision.gameObject);

        }
    }
    
    private void Attack()
    {
        Instantiate(attackPower, attackPoint.transform.position, attackPoint.transform.rotation);
    }


    void CheckVictory()
    {
        if (bossHealth <= 0)
        {
            isDead = true;
            CancelInvoke(nameof(Unparalyze));
            anim.SetBool("Died", true);
            Invoke("Victory", 5f);
            
        }
    }

  

    public void TakeDamage()
    {
        if (isDead) return;

        bossHealth--;

        CheckVictory();
    }


    public void Victory()
    {
     SceneManager.LoadScene("Victory");
    }


    private void Paralize()
    {
        isParalyzed = true;
        speed = 0;
        CancelInvoke(nameof(Unparalyze));
        Invoke(nameof(Unparalyze), paralyzeDuration);
    }

    private void Unparalyze()
    {
        if (isDead) return;

        isParalyzed = false;
        speed = originalSpeed;
    }
}
