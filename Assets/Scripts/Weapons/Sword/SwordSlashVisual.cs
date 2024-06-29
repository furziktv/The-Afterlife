using System;
using UnityEngine;

public class SwordSlashVisual : MonoBehaviour
{
    [SerializeField] private Sword sword;
    private Animator animator;
    private const string ATTACK = "Attack";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        sword.OnSwordSwing+= SwordSlashOnSwordSwing;
    }

    private void SwordSlashOnSwordSwing(object sender, EventArgs e)
    {
        animator.SetTrigger(ATTACK);
    }
}
