using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction to move towards the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Move the enemy towards the player
        enemyRb.AddForce(lookDirection * speed);

        // Check if the enemy is below the map's y position
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    // This method is called whenever the enemy collides with something
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the map's collider
        if (collision.collider.CompareTag("MapCollider"))
        {
            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}
