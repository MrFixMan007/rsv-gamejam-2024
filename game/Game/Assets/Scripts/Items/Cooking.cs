using System;
using UnityEngine;

public class Cooking : Item
{
    public TimeBar time_bar;

    public bool ReadyMeat; 
    public bool ReadyVegetables;
    private Animator _animator;
    [SerializeField] private float timeToCook = 10;
    private float step;

    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        step += Time.fixedDeltaTime;
        if (step >= timeToCook)
        {
            _animator.SetBool("Cooked", true);
        }
    }

    public override void Use()
    {
        if (player.Inventory.Item is ItemMeat)
        {
            ReadyMeat = true;
        }
        else if (player.Inventory.Item is ItemVegetables)
        {
            ReadyVegetables = true;
        }

        if (ReadyMeat && ReadyVegetables)
        {
            _animator.SetBool("Cook", true);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        player.ItemCanInteract = this;
    }
    
    protected override void OnTriggerExit2D(Collider2D other)
    {
        player.ItemCanInteract = null;
    }
}
