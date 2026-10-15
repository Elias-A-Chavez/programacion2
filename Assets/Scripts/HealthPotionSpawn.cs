using UnityEngine;

public class HealthPotionSpawn : MonoBehaviour
{

    public GameObject playerHealth;
    
    [SerializeField] float currentHealth;
    
    [SerializeField] private GameObject healthPotion;
    



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerHealth.GetComponent<PlayerMovement>().health;
        if (currentHealth < 15)
        {
            Instantiate(healthPotion, transform.position, transform.rotation);

        }
    }
}
