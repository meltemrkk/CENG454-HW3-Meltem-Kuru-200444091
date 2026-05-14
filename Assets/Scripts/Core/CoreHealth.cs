using System;
using UnityEngine;

public class CoreHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    public float CurrentHealth { get; private set; }
    public static event Action<float, float> OnCoreHealthChanged; 
    public static event Action OnCoreDestroyed;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (CurrentHealth <= 0) return;

        CurrentHealth -= amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

        OnCoreHealthChanged?.Invoke(CurrentHealth, maxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnCoreDestroyed?.Invoke();
        gameObject.SetActive(false);
    }
}