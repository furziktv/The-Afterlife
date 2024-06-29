using System;
using UnityEngine;

public class XP : MonoBehaviour
{
    [SerializeField] private float _xp;
    public Transform _playerTransform;

    [SerializeField] private float _speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out PlayerHP playerHp))
        {
            playerHp.GetXP(_xp);
            Destroy(gameObject);
        }
    }
}
