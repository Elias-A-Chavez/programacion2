using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour, IDamageable
{
    [SerializeField] private int speed;
    [SerializeField] private Animator anim;
    [SerializeField] private float health;
    [SerializeField] private GameObject iceAttack;
    [SerializeField] private GameObject specialAttack;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float mana;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image healthBar;
    [SerializeField] private float chargeAttack;
    private IMagic attack;
    private IMagic iceMagic;
    private IMagic specialMagic;



    void Start()
    {
        iceMagic = new PlayerAttack();
        specialMagic = new SpecialAttack();
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
                attack = iceMagic;
                attack.Attack(iceAttack, attackPoint);
                mana -= 1f;
                chargeAttack += 1f;
            }
           

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            if (chargeAttack >= 10f)
            {
                if (mana >= 5f)
                {
                    attack = specialMagic;
                    attack.Attack(specialAttack, attackPoint);
                    mana -= 5f;
                    chargeAttack = 0f;
                }
            }
            
        }


        healthBar.fillAmount = health / 30f;
        manaBar.fillAmount = mana / 10f;
        
    }
    public float Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0f, 30f);
        }
    }
    public float Mana
    {
        get => mana;
        set
        {
            mana = Mathf.Clamp(value, 0f, 10f);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.gameObject.GetComponentInParent<IInteractable>();

        if (interactable != null)
        {
            
            interactable.Interact();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BeeSting"))
        {

            Destroy(collision.gameObject);

            if (health <= 0)
            {
                anim.SetBool("Death", true);

                Invoke("Defeat", 5f);
            }

        }

      

    }

    public void TakeDamage()
    {
        health--;
    }

    public void Defeat()
    {
        SceneManager.LoadScene("Defeat");
    }
    
       
    

    

    
}
