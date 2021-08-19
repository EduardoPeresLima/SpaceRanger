using UnityEngine;
using Asteroids;
namespace Ship
{
    public class ShipHealth : MonoBehaviour
    {
        private int hitsItCanTake;
        [SerializeField] private GameObject HealthPanel;
        [SerializeField] private GameObject LifePrefab;
        
        private void Start()
        {
            hitsItCanTake = 3;
            for (int i = 0; i < hitsItCanTake; i++)  Instantiate(LifePrefab, HealthPanel.transform);
        }

        public void IncreaseHealth()
        {
            hitsItCanTake++;
            Instantiate(LifePrefab, HealthPanel.transform);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Asteroid")) return;
            other.GetComponent<AsteroidController>().Death();
            Death();
        }
        private void Death()
        {
            //Explosion
            hitsItCanTake--;
            Destroy(HealthPanel.transform.GetChild(hitsItCanTake).gameObject);
            if (hitsItCanTake <= 0)
            {
                GameManager.Instance.GameOver();
                Destroy(gameObject);
            }
            else
            {
                //Hit Animation
            }
        }
    }
}
