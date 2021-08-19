using UnityEngine;
using Asteroids;

namespace Projectile
{
    public class ProjectileMovement : MonoBehaviour
    {
        private const float maxYToDie = 15f;
        private const float upVelocity = 2f;
        private Rigidbody2D rig;

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            rig.velocity = Vector2.up * upVelocity;
        }

        private void Update()
        {
            VerifyGamePaused();
            VerifyDeath();
        }

        private void VerifyGamePaused()
        {
            if (GameManager.Instance.GamePaused) rig.velocity = Vector2.zero;
            else rig.velocity = Vector2.up * upVelocity;
        }

        private void VerifyDeath()
        {
            if (transform.position.y > maxYToDie) Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Asteroid")) return;
            AsteroidController asteroid = other.GetComponent<AsteroidController>();
            GameManager.Instance.AddPoints(asteroid.pointsGivenWheDestroyed);
            GameManager.Instance.AddCoins(asteroid.coinsGivenWheDestroyed);
            asteroid.Death();
            Death();
        }

        private void Death()
        {
            //Explosion
            Destroy(gameObject);
        }
    }
}