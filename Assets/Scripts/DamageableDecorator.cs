using UnityEngine;

public abstract class DamageableDecorator : IDamageable
{
    protected IDamageable wrappedEntity;

    public DamageableDecorator(IDamageable entityToWrap)
    {
        wrappedEntity = entityToWrap;
    }

    public float CurrentHealth => wrappedEntity.CurrentHealth;

    public virtual void Die()
    {
        wrappedEntity.Die();
    }

    public virtual void TakeDamage(float amount)
    {
        wrappedEntity.TakeDamage(amount);
    }
}