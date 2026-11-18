using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : Enemies, IDamageable
{
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject attackPower;
    [SerializeField] private int bossHealth;
    float timer;
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
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
            
            CheckVictory();
            

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
            anim.SetBool("Died", true);
            Invoke("Victory", 5f);
            //SceneManager.LoadScene("Victory");
            bossHealth = 12;
        }
    }

    public void TakeDamage()
    {
        bossHealth--;
    }
}
