using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    private IAttackBehavior currentAttackStrategy;
    public Transform targetCore;

    private void Start()
    {
        SetStrategy(new DirectAttackStrategy());
    }

    public void SetStrategy(IAttackBehavior newStrategy)
    {
        currentAttackStrategy = newStrategy;
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (targetCore != null)
            {
                currentAttackStrategy.ExecuteAttack(transform, targetCore);
            }
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SetStrategy(new DirectAttackStrategy());
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SetStrategy(new FlankAttackStrategy());
        }
    }
}