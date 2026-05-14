using UnityEngine;

public class ShieldUpgrade : DamageableDecorator
{
    private float damageReductionMultiplier = 0.5f; 

    public ShieldUpgrade(IDamageable entityToWrap) : base(entityToWrap)
    {
    }

    public override void TakeDamage(float amount)
    {
        float reducedDamage = amount * damageReductionMultiplier;
        Debug.Log($"[Kalkan Aktif] Gelen orijinal hasar: {amount}. Kalkan sayesinde {reducedDamage} hasar alýndý!");

        base.TakeDamage(reducedDamage);
    }
}