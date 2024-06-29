using System;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Sprite _doorOpenSprite;
    [SerializeField] private Sprite _doorExitSprite;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void DoorOpen()
    {
        _boxCollider2D.enabled = false;
        _spriteRenderer.sprite = _doorOpenSprite;
    }

    public void DoorClose()
    {
        _boxCollider2D.enabled = true;
        _spriteRenderer.sprite = _doorExitSprite;
    }
}
