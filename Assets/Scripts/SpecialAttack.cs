using UnityEngine;

public class SpecialAttack : IMagic
{
    public void Attack(GameObject specialAttack, GameObject attackPoint)
    {
        Object.Instantiate(specialAttack, attackPoint.transform.position, attackPoint.transform.rotation);
    }

   
}
