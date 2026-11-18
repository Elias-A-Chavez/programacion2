using UnityEngine;

public class HealthPotionSpawn : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject playerHealth;

    [SerializeField] private float currentHealth;
    [SerializeField] private GameObject healthPotion;

    private PlayerMovement playerMovement;
    private bool potionSpawned = false;

    public void Interact()
    {
        if (playerMovement != null)
        {
            playerMovement.Health += 10f;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (playerHealth != null)
        {
            playerMovement = playerHealth.GetComponent<PlayerMovement>();
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

        currentHealth = playerMovement.Mana;

        if (currentHealth < 15f && !potionSpawned)
        {
            Instantiate(healthPotion, transform.position, transform.rotation);
            potionSpawned = true;
        }
        else if (currentHealth >= 15f)
        {
            potionSpawned = false;
        }
    }
}
