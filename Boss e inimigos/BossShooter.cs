using UnityEngine;

public class BossShooter : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint; 
    private float cooldown = 3f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
