using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected int speed;



    protected virtual void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }


    protected virtual void Update()
    {
        if (player == null) return;
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * Time.deltaTime * speed);

    }

}

