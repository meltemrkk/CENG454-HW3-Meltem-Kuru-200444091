using UnityEngine;

public class CoreEffectManager : MonoBehaviour
{
    private void OnEnable()
    {
        CoreHealth.OnCoreHealthChanged += HandleCoreHealthChanged;
        CoreHealth.OnCoreDestroyed += HandleCoreDestroyed;
    }

    private void OnDisable()
    {
        CoreHealth.OnCoreHealthChanged -= HandleCoreHealthChanged;
        CoreHealth.OnCoreDestroyed -= HandleCoreDestroyed;
    }

    private void HandleCoreHealthChanged(float currentHealth, float maxHealth)
    {
        Debug.Log($"[EffectManager] Çekirdek hasar aldý! Kalan Can: {currentHealth}/{maxHealth}");
    }

    private void HandleCoreDestroyed()
    {
        Debug.Log("[EffectManager] ÇEKÝRDEK PATLADI! BOOOM!");
    }
}