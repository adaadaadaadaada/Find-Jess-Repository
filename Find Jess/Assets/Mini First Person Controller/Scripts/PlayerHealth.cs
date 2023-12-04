using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;
    public EnemyMovement enemyMovement;
    public GameManagerScript gameManager;

    public GameObject player;
    public GameObject enemy;
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
            if (IsPlayerNearEnemy())
            {
                Attack();
                TakeDamage(1);
            }
        }
    }
    void Attack()
    {
        nextAttackTime = Time.time + cooldownTime;
    }
    bool IsPlayerNearEnemy()
    {

        float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
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
