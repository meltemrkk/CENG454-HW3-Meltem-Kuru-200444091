using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    public float speed = 20f;
    public float lifeTime = 2f;
    public float damage = 10f;

    private float timer;

    public void OnObjectSpawn()
    {
        timer = 0f;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
