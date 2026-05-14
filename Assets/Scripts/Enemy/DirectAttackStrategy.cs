using UnityEngine;

public class DirectAttackStrategy : IAttackBehavior
{
    public void ExecuteAttack(Transform attacker, Transform target)
    {
        Debug.Log("Düþman doðrudan ateþ ediyor!");

        GameObject bullet = ObjectPooler.Instance.SpawnFromPool("EnemyBullet", attacker.position + attacker.forward, attacker.rotation);

        if (bullet != null)
        {
            bullet.transform.LookAt(target.position);
        }
    }
}