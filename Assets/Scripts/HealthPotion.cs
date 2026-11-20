using UnityEngine;

public class HealthPotion : MonoBehaviour, IInteractable
{
    [SerializeField] private float healAmount = 10f;

    public void Interact()
    {
        PlayerMovement player = FindFirstObjectByType<PlayerMovement>();

        if (player != null)
        {
            player.Health += healAmount;
            Destroy(gameObject); 
        }
    }
}
