using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float chargeSpeed = 10.0f;
    public float movementRadius = 5.0f;
    private Rigidbody2D rb;

    private float chargeInterval = 5.0f;
    private float currentChargeInterval = 0.0f;
    private float finalChargeInterval = 2.5f;

    private float gameTime = 0.0f;
    public float winTime = 60.0f;
    public string loseSceneName = "gameover";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime >= winTime)
        {
            SceneManager.LoadScene("gameclear");
        }

        currentChargeInterval += Time.deltaTime;

        if (currentChargeInterval >= chargeInterval)
        {
            Charge();
            currentChargeInterval = 0.0f;
        }

        if (gameTime >= 30.0f)
        {
            chargeInterval = finalChargeInterval;
        }
    }

    void Charge()
    {
        Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
        rb.AddForce(direction * chargeSpeed, ForceMode2D.Impulse);
        Invoke("StopCharge", 1.0f);
    }

    void StopCharge()
    {
        rb.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("gameover");
        }
    }
}