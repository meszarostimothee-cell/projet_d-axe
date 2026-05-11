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

        // Désactive la hitbox au début
        hitbox.enabled = false;
    }

    void Update()
    {
        // Clique gauche
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        // Active la hitbox
        hitbox.enabled = true;

        // Attend un peu
        yield return new WaitForSeconds(attackDuration);

        // Désactive la hitbox
        hitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();

            if (enemyRb != null)
            {
                // Direction du push
                Vector2 direction = (collision.transform.position - transform.position).normalized;

                // Applique la force
                enemyRb.AddForce(direction * pushForce, ForceMode2D.Impulse);
            }





        }
    }
}




