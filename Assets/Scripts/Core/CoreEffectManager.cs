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

    private void HandleCoreHealthChanged(float currentHealth)
    {
        Debug.Log($"[EffectManager] Çekirdek hasar efekti oynatýldý! Güncel Can: {currentHealth}");
    }

    private void HandleCoreDestroyed()
    {
        Debug.Log("[EffectManager] Çekirdek patlama efekti (VFX) oynatýldý!");
    }
}