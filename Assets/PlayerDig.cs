

using UnityEngine;

public class PlayerDig : MonoBehaviour
{
    public Vector2 normalSize = new Vector2(1f, 1f);
    public Vector2 digSize = new Vector2(1f, 0.5f);

    public float normalGravity = 1f;
    public float fastFallGravity = 10f;

    // Sprites
    public Sprite normalSprite;
    public Sprite digSprite;

    // Particules de terre
    public ParticleSystem dirtParticles;

    private SpriteRenderer sr;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private bool isGrounded;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Maintenir S pour creuser
        if (Input.GetKey(KeyCode.S))
        {
            // Sprite creusage
            sr.sprite = digSprite;

            // Particules ON
            if (dirtParticles != null && isGrounded)
            {
                if (!dirtParticles.isPlaying)
                {
                    dirtParticles.Play();
                }
            }

            // Si au sol = se baisser / creuser
            if (isGrounded)
            {
                boxCollider.size = digSize;
            }
            // Sinon = tomber plus vite
            else
            {
                rb.gravityScale = fastFallGravity;
            }
        }
        else
        {
            // Sprite normal
            sr.sprite = normalSprite;

            // Taille normale
            boxCollider.size = normalSize;

            // Gravité normale
            rb.gravityScale = normalGravity;

            // Particules OFF
            if (dirtParticles != null && dirtParticles.isPlaying)
            {
                dirtParticles.Stop();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}