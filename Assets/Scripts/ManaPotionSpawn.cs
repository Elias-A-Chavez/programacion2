using UnityEngine;

public class ManaPotionSpawn : MonoBehaviour
{

    [SerializeField] private GameObject manaPotionPrefab;
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


        if (playerMovement.Mana < 3f && currentPotion == null)
        {
            currentPotion = Instantiate(manaPotionPrefab, transform.position, transform.rotation);
        }
    }
}