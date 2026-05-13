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
                currentAttackStrategy.ExecuteAttack(targetCore);
            }
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SetStrategy(new DirectAttackStrategy());
            Debug.Log("Strateji deðiþti: Doðrudan Saldýrý");
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SetStrategy(new FlankAttackStrategy());
            Debug.Log("Strateji deðiþti: Taktiksel Saldýrý (Flank)");
        }
    }
}