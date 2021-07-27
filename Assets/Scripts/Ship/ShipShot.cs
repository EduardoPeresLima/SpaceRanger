using UnityEngine;

public class ShipShot : MonoBehaviour
{
    [SerializeField] private Transform projectileParent;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float timeBetweenShots = 0.25f;
    private float time;

    private void Start()
    {
        time = timeBetweenShots;
    }

    void Update()
    {
        if (GameManager.Instance.GamePaused) return;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Shoot();
            time = timeBetweenShots;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab,projectileSpawnPoint.position,Quaternion.identity,projectileParent);
    }
}
