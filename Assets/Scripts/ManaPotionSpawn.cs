using UnityEngine;

public class ManaPotionSpawn : MonoBehaviour
{


    
    public GameObject playerMana;
    
    [SerializeField] float currentMana;
    
    [SerializeField] private GameObject manaPotion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        currentMana = playerMana.GetComponent<PlayerMovement>().mana;
        if (currentMana < 3)
        {
            Instantiate(manaPotion, transform.position, transform.rotation);

        }
    }
}
