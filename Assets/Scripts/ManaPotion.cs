using UnityEngine;

public class ManaPotion : MonoBehaviour, IInteractable
{
    [SerializeField] private float rechargeAmount = 5f;

    public void Interact()
    {
        PlayerMovement player = FindFirstObjectByType<PlayerMovement>();

        if (player != null)
        {
            player.Mana += rechargeAmount;
            Destroy(gameObject);
        }
    }
}
