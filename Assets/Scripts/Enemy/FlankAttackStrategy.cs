using UnityEngine;

public class FlankAttackStrategy : IAttackBehavior
{
    public void ExecuteAttack(Transform target)
    {
        Debug.Log("Düþman taktiksel olarak etraftan dolanarak saldýrýyor! (5 Hasar)");

        var damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(5f);
        }
    }
}