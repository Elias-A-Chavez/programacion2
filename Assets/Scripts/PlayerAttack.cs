using UnityEngine;

public class PlayerAttack : IMagic
{
    
    public void Attack(GameObject iceAttack, GameObject attackPoint)
    {
        Object.Instantiate(iceAttack, attackPoint.transform.position, attackPoint.transform.rotation);
    }

    

}
