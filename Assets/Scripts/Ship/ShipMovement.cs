using UnityEngine;

namespace Ship
{
    public class ShipMovement : MonoBehaviour
    {
        private enum Facing
        {
            Left = -1,
            Front = 0,
            Right = 1
        };

        private Facing facing = Facing.Front;
        [SerializeField] private float velocity = 2f;
        private Animator _animator;
        private Rigidbody2D rig;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            UpdateShipDirection();
            Move();
        }

        private void UpdateShipDirection()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) facing = Facing.Left;
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) facing = Facing.Right;
            else facing = Facing.Front;
        }

        private void Move()
        {
            _animator.SetInteger("Direction", (int) facing);
            rig.velocity = (velocity * (int) facing) * Vector2.right;
        }
    }
}
