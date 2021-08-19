using System.Collections;
using UnityEngine;

namespace Ship
{
    public class ShipShot : MonoBehaviour
    {
        [SerializeField] private Transform projectileParent;
        [SerializeField] private Transform projectileSpawnPoint;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float timeBetweenShots = 0.25f;
        private float timeToShot;

        private void Start() => timeToShot = 0;

        private void Update()
        {
            if (GameManager.Instance.GamePaused) return;
            if (Input.GetMouseButton(0))
            {
                timeToShot -= Time.deltaTime;
                if (timeToShot <= 0)
                {
                    Shoot();
                    timeToShot = timeBetweenShots;
                }
            }
            else timeToShot = 0;
        }

        private void Shoot()
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity, projectileParent);
        }

        public void TemporaryIncreaseShotRate(float tempTimeIncreaseShot) => StartCoroutine(DelayIncreaseShotRate(tempTimeIncreaseShot));

        private IEnumerator DelayIncreaseShotRate(float tempTimeIncreaseShot)
        {
            float initialTimeBetweenShots = timeBetweenShots;
            timeBetweenShots /= 2;
            float tempTime = tempTimeIncreaseShot;
            while (tempTime >= 0)
            {
                if (GameManager.Instance.GamePaused) continue;
                tempTime -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            timeBetweenShots = initialTimeBetweenShots;
        }
    }
}