using UnityEngine;

namespace Player
{
    public class Jumper
    {
        private readonly Rigidbody _rb;
        private readonly float _jumpForce;
        private readonly LayerMask _groundMask;
        private readonly float _groundCheckDistance = 2.4f;

        public Jumper(Rigidbody rb, float jumpForce, LayerMask groundMask)
        {
            _rb = rb;
            _jumpForce = jumpForce;
            _groundMask = groundMask;
        }

        public void TryJump(bool jumpRequested)
        {
            Debug.Log(("Jumper jump requested ") + IsGrounded());
            if (jumpRequested && IsGrounded())
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(_rb.position, Vector3.down, _groundCheckDistance, _groundMask);
        }
    }
}