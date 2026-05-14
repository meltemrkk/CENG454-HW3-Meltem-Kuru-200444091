using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoreHealth : MonoBehaviour, IDamageable
{
    public static event Action<float> OnCoreHealthChanged;
    public static event Action OnCoreDestroyed;

    public float maxHealth = 100f;
    private float currentHealth;
    public float CurrentHealth => currentHealth;

    private IDamageable damageHandler;

    private class RawHealth : IDamageable
    {
        private CoreHealth core;
        public RawHealth(CoreHealth core) { this.core = core; }

        public float CurrentHealth => core.CurrentHealth;
        public void Die() { core.Die(); }
        public void TakeDamage(float amount) { core.ApplyRawDamage(amount); } 
    }

    private void Start()
    {
        currentHealth = maxHealth;
        damageHandler = new RawHealth(this);
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ApplyShield();
        }
    }

    public void ApplyShield()
    {
        damageHandler = new ShieldUpgrade(new RawHealth(this));
        Debug.Log("Çekirdeðe kalkan yükseltmesi uygulandý!");
    }

    public void TakeDamage(float amount)
    {
        damageHandler.TakeDamage(amount);
    }

    public void ApplyRawDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"[EffectManager] Çekirdek hasar aldý! Kalan Can: {currentHealth}/{maxHealth}");

        OnCoreHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Çekirdek yok oldu!");
        OnCoreDestroyed?.Invoke();
    }
}