using UnityEngine;

public class specialMagic : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5);
    }


    void Update()
    {
        transform.Translate(35 * Time.deltaTime, 0, 0);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage();
        }

        Enemies enemy = collision.gameObject.GetComponent<Enemies>();
        if (enemy != null)
        {
            Destroy(gameObject);
        }
    }
}