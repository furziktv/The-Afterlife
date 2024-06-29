using System;
using UnityEngine;

    [SelectionBase]
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }
        
        public float speed;
        
        private Rigidbody2D rb;
        private Vector2 inputVector;
        private float minMovingSpeed = 0.1f;
        private bool isRunning;

        private void Awake()
        {
            Instance = this;
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            GameInput.Instance.OnPlayerAttack += Player_OnPlayerAttack;
        }

        private void Player_OnPlayerAttack(object sender, EventArgs e)
        {
           ActiveWeapon.Instance.GetActiveWeapon().Attack();
        }

        private void Update()
        {
            inputVector = GameInput.Instance.GetMovementVector();
            HandleMovementRun();
        }

        private void FixedUpdate()
        {
            HandleMovement();
            
        }

        private void HandleMovement()
        {
            rb.MovePosition(rb.position + inputVector * speed * Time.fixedDeltaTime);
            inputVector = Vector2.zero;
            
        }

        private void HandleMovementRun()
        {
            if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
        }

        public bool IsRunning()
        {
            return isRunning;
        }

        public Vector3 GetPlayerScreenPosition()
        {
            Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
            return playerScreenPosition;
        }
    }
