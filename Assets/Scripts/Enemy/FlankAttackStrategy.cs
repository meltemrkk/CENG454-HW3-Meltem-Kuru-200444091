using UnityEngine;

public class FlankAttackStrategy : IAttackBehavior
{
    public void ExecuteAttack(Transform attacker, Transform target)
    {
        Debug.Log("Düþman taktiksel saldýrýyor (Yakýn Dövüþ)!");

        var damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(5f);
        }
    }
}