
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public float health = 50f;
    Vector3 pos;
    Animator anim;
    public Transform goal;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;


    private void Start()
    {
        pos = transform.position;
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        anim = GetComponent<Animator>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        if (pos != transform.position)
        {
            anim.SetBool("condition", true);
            
        }
        else  
        {
            anim.SetBool("condition", false);

            //TakeDamagePY(1);
        }
        pos = transform.position;

    }

    public void TakeDamageEnemy (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            anim.SetBool("die", true);
            Destroy(gameObject);
        }
    }
     void TakeDamagePY(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth<=0) //ถ้าเลือดหมดให้โหลดซีน
        {
            SceneManager.LoadScene("Dead");
            currentHealth = maxHealth;
            Cursor.lockState = CursorLockMode.None; //ให้เม้ากลับมาปกติไม่ล็อคไว้
            CoinData.Coin = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakeDamagePY(30);
        }
    }
}
