using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : ItemBase2D
{
    [SerializeField] int Atu = 1;
    public override void Activate()
    {
        FindObjectOfType<PlayerController>().AddDamege(Atu);
    }
}
