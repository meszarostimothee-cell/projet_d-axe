using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 3f;

    private Transform player;
    private bool canChase = false;

    void Start()
    {
        // Trouve le joueur
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Si l'ennemi peut poursuivre
        if (canChase && player != null)
        {
            // Direction vers le joueur
            Vector2 direction = (player.position - transform.position).normalized;

            // Déplacement
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }
    }

    // Quand l'ennemi apparaît à l'écran
    private void OnBecameVisible()
    {
        canChase = true;
    }
}

