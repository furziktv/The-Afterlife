using System;
using UnityEngine;
public class PlayerVisual : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _playerSprite;
        private PlayerHP _playerHp;

        private const string IS_RUNNING = "Run";
        private const string TAKEDAMAGE = "TakeDamage";
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerSprite = GetComponent<SpriteRenderer>();
            _playerHp = GetComponentInParent<PlayerHP>();
        }

        private void Start()
        {
            _playerHp.onTakeDamage += PlayerHpOnonTakeDamage;
        }

        private void OnDestroy()
        {
            _playerHp.onTakeDamage -= PlayerHpOnonTakeDamage;
        }

        // Update is called once per frame
        void Update()
        {
            _animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
            AdjustPlayerFacingDerection();
        }
        private void PlayerHpOnonTakeDamage(object sender, EventArgs e)
        {
            _animator.SetTrigger(TAKEDAMAGE);
        }

        private void AdjustPlayerFacingDerection()
        {
            Vector3 mousePos = GameInput.Instance.GetMousePosition();
            Vector3 playerPosition = Player.Instance.GetPlayerScreenPosition();
            if (mousePos.x < playerPosition.x)
                _playerSprite.flipX = true;
            else
                _playerSprite.flipX = false;
        }
    }

