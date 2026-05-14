using UnityEngine;

public interface IAttackBehavior
{
    void ExecuteAttack(Transform attacker, Transform target);
}