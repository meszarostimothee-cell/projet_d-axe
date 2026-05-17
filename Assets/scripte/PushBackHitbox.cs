using UnityEngine;
using System.Collections;

public class PushBackHitbox : MonoBehaviour
{
    public float pushForce = 10f;
    public float attackDuration = 0.2f;

    private Collider2D hitbox;

    void Start()
    {
        hitbox = GetComponent<Collider2D>();


        hitbox.enabled = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {

        hitbox.enabled = true;


        yield return new WaitForSeconds(attackDuration);


        hitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();

            if (enemyRb != null)
            {
                
                Vector2 direction = (collision.transform.position - transform.position).normalized;

                
                enemyRb.AddForce(direction * pushForce, ForceMode2D.Impulse);

                
                EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

                
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(1);
                }
            }
        }
    }
}




