using System.Collections;
using UnityEngine;

public class PatrolNew : MonoBehaviour
{
    [SerializeField] private Transform pfDamagePopup;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public HealthBar HealthBar;
    public GameObject hitExplosion;


    
    public float walkingSpeed;
    public int currentDirection;
    public float groundCheckDistance;

    public int maxHealth = 10;
    public int currentHealth;

    private bool dead = false;
    private bool stunned = false;
    private bool currentlyFlipping = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.animator = GetComponent<Animator>();

        this.currentHealth = maxHealth;


        spriteRenderer.flipX = this.currentDirection < 0;
    }

    private IEnumerator DoFlip()
    {
        this.currentDirection *= -1;
        this.spriteRenderer.flipX ^= true; // flipX = !flipX
        this.currentlyFlipping = true;
        yield return new WaitForSeconds(0.25f);
        this.currentlyFlipping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            this.rigidbody.velocity = Vector2.zero;
            return;
        }
        Bounds bounds = boxCollider.bounds;
        Vector2[] bottomCorners = new Vector2[] { 
            new Vector2(bounds.center.x - bounds.extents.x, bounds.center.y - bounds.extents.y), 
            new Vector2(bounds.center.x + bounds.extents.x, bounds.center.y - bounds.extents.y) 
        };
        foreach (Vector2 position in bottomCorners)
        {
            RaycastHit2D raycast = Physics2D.Raycast(position, Vector2.down, groundCheckDistance, LayerMask.GetMask("Ground"));

            if (raycast.collider == null && !this.currentlyFlipping)
            {
                StartCoroutine(DoFlip());
            }
            // for (Transform transform : groundCastOrigins) <-- Java Äquivalenz
        }

        if (!stunned)
        {
            this.rigidbody.velocity = new Vector3(currentDirection * walkingSpeed, 0.0f, 0.0f);
        }
        else
        {
            this.rigidbody.velocity = Vector2.zero;
        }
    }

   /* void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
           // Debug.Log("damage taken");
           
            HealthBar.TakeDamage();
        }
    }
   */
    private IEnumerator DoStun(float time)
    {
        this.animator.SetBool("stunned", true);
        yield return new WaitForSeconds(time);
        this.stunned = false;
        this.animator.SetBool("stunned", false);
    }

    private IEnumerator Die()
    {
        ScoreManager.instance.AddPoint();
        this.animator.SetBool("dead", true);
        yield return new WaitForSeconds(0.5f);
        ScoreManager.instance.Enemyremove();
        DestroyImmediate(gameObject);
    }

    public void TakeDamage(int amount)
    {

        

        // think about some better way of doing this
        float stunTime = 0.333333f;
        
        Transform damagePopupTransform = Instantiate(pfDamagePopup, gameObject.transform.position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(amount);
        this.stunned = true;
        this.currentHealth -= amount;
        Instantiate(hitExplosion, transform.position, Quaternion.identity);
        // TODO: take damage

        if (this.currentHealth <= 0.0)
        {
            this.dead = true;
            this.StartCoroutine(Die());
        } else
        {
            StartCoroutine(DoStun(stunTime));
        }
    }
}
