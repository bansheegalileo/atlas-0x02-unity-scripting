using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private int score = 0;
    public int health = 5;
    void Start()
    {
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        
        transform.Translate(movement * speed * Time.fixedDeltaTime, Space.World);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
        else if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }

    void Update()
    {
        if (health == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");

        health = 5;
        score = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
