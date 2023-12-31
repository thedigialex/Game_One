using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float movementSpeed = 5f;
    public float shootForce = 10f;
    public float despawnDelay = 3f;
    private Rigidbody rb;
    private PlayerStats playerStats;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerStats = GetComponent<PlayerStats>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed *= 2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed /= 2f;
        }
    }

    private void FixedUpdate()
    {
        if (playerStats.currentHealth > 0) 
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * movementSpeed;
            rb.velocity = movement;
        }
    }
    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        if (projectileRigidbody != null)
        {
            projectileRigidbody.AddForce(spawnPoint.forward * shootForce, ForceMode.Impulse);
        }
        StartCoroutine(DestroyAfterDelay(projectile, despawnDelay));
    }
    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}

