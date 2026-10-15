using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject stingPoint;
    [SerializeField] private Animator anim;
    [SerializeField] int speed;
    [SerializeField] private GameObject beeSting;
    public static int enemiesKilled = 0;
    float timer;

    void Start()
    {
        if (enemiesKilled >= 5)
        {
            enemiesKilled = 0;
        }

        Destroy(gameObject, 15);
    }

    
    void Update()
    {
        if (player == null) return;
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * Time.deltaTime * speed);
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Instantiate(beeSting, stingPoint.transform.position, stingPoint.transform.rotation);
            timer = 0;
            

        }
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("IceAttack"))
        {
            enemiesKilled++;
            
            CheckVictory();
            Destroy(gameObject);
            
            
        }
    }
    void CheckVictory()
    {
        if (enemiesKilled >= 3)
        {
            enemiesKilled = 0;

            SceneManager.LoadScene("Victory");
        }
    }

      
}
