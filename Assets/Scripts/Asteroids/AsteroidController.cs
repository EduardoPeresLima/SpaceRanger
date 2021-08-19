using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : MonoBehaviour
{
    public int pointsGivenWheDestroyed;
    public int coinsGivenWheDestroyed;
    private const float minVelocity = 1f;
    private const float maxVelocity = 4f;
    private const float minYToDie = -5f;
    private Rigidbody2D rig;
    private float velocity;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        velocity = Random.Range(minVelocity, maxVelocity);
        rig.velocity = velocity * Vector2.down;
    }
    void Update()
    {
        VerifyGamePaused();
        VerifyDeathByOffBounds();
    }

    void VerifyGamePaused()
    {
        if(GameManager.Instance.GamePaused)rig.velocity = Vector2.zero;
        else rig.velocity = velocity * Vector2.down;
    }
    void VerifyDeathByOffBounds()
    {
        if (transform.position.y < minYToDie) Death();
    }

    public void Death()
    {
        //Explosion
        Destroy(gameObject);
    }
}
