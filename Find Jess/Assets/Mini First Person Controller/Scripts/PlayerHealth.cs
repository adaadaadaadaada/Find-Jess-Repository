using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public AudioSource biteSFX;

    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;
    public EnemyMovement enemyMovement;
    public GameManagerScript gameManager;

    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float cooldownTime = 5f;
    public float detectionRadius = 1f;
    private float nextAttackTime = 5f;

    private bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (IsPlayerNearEnemy1())
            {
                Attack();
                TakeDamage(1);
                biteSFX.Play();
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (IsPlayerNearEnemy2())
            {
                Attack();
                TakeDamage(1);
                biteSFX.Play();
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (IsPlayerNearEnemy3())
            {
                Attack();
                TakeDamage(1);
                biteSFX.Play();
            }
        }
    }
    void Attack()
    {
        nextAttackTime = Time.time + cooldownTime;
    }
    bool IsPlayerNearEnemy1()
    {

        float distance = Vector3.Distance(player.transform.position, enemy1.transform.position);
        return distance <= detectionRadius;
    }
    bool IsPlayerNearEnemy2()
    {

        float distance = Vector3.Distance(player.transform.position, enemy2.transform.position);
        return distance <= detectionRadius;
    }
    bool IsPlayerNearEnemy3()
    {

        float distance = Vector3.Distance(player.transform.position, enemy3.transform.position);
        return distance <= detectionRadius;
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.GameOver();


        }
    }
}
