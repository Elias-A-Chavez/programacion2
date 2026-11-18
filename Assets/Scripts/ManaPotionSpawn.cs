using UnityEngine;

public class ManaPotionSpawn : MonoBehaviour, IInteractable
{



    [SerializeField]  private GameObject playerMana;
    
    [SerializeField] float currentMana;
    
    [SerializeField] private GameObject manaPotion;
    private PlayerMovement playerMovement;
    private bool potionSpawned = false;



    public void Interact()
    {
        if (playerMovement != null)
        {
            playerMovement.Mana += 5f;
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (playerMana != null)
        {
            playerMovement = playerMana.GetComponent<PlayerMovement>();
        }
        if (playerMovement == null)
        {
            playerMovement = FindFirstObjectByType<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement == null) return;

        currentMana = playerMovement.Mana;

        if (currentMana < 3f && !potionSpawned)
        {
            Instantiate(manaPotion, transform.position, transform.rotation);
            potionSpawned = true;
        }
        else if (currentMana >= 3f)
        {
            potionSpawned = false;
        }

        //if (currentMana < 3)
        {
            //Instantiate(manaPotion, transform.position, transform.rotation);
            
        }
        

        //currentMana = playerMana.GetComponent<PlayerMovement>().mana;
        //if (currentMana < 3)
        {
            //Instantiate(manaPotion, transform.position, transform.rotation);

        }
    }
}
