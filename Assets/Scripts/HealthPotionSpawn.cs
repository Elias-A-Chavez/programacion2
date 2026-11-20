using NUnit.Framework;
using UnityEngine;

public class HealthPotionSpawn : MonoBehaviour
{

    [SerializeField] private GameObject healthPotionPrefab;
    [SerializeField] private PlayerMovement playerMovement;
    

    private GameObject currentPotion;

    void Start()
    {
        if (playerMovement == null)
        {
            playerMovement = FindFirstObjectByType<PlayerMovement>();
        }
    }

    void Update()
    {
        if (playerMovement == null) return;

        
        if (playerMovement.Health < 15f && currentPotion == null)
        {
            currentPotion = Instantiate(healthPotionPrefab, transform.position, transform.rotation);
           
        }
    }
}
