using UnityEngine;

public class DirectAttackStrategy : IAttackBehavior
{
    public void ExecuteAttack(Transform target)
    {
        Debug.Log("Düþman doðrudan çekirdeðe saldýrýyor! (10 Hasar)");

        var damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(10f);
        }
    }
}