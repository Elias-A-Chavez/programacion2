using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] private Animator anim;
    public float health;
    [SerializeField] private GameObject iceAttack;
    [SerializeField] private GameObject attackPoint;
    public float mana;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image healthBar;
    

    void Start()
    {

    }

    void Update()
    {
        bool isRunning = false;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);

            isRunning = true;

            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            
            isRunning = true;

            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        anim.SetBool("Run", isRunning);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(mana > 0)
            {
                Instantiate(iceAttack, attackPoint.transform.position, attackPoint.transform.rotation);
                mana--;
                
            }
            
        }


        healthBar.fillAmount = health / 30f;
        manaBar.fillAmount = mana / 10f;


        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BeeSting"))
        {
            health--; 
            Destroy(collision.gameObject);
            

            if (health <= 0)
            {
                anim.SetBool("Death", true);

                Invoke("Defeat", 5f);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealthPotion"))
        {
            health = 20;
            Destroy(collision.gameObject);
        }
         else if (collision.gameObject.CompareTag("ManaPotion"))
        {
            mana = 10;
            Destroy(collision.gameObject);
        }
    }
    

    

    void Defeat()
    {
        SceneManager.LoadScene("Defeat");
    }

   
}
