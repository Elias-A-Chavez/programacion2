using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 6)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0;
        }
        
    }
}
