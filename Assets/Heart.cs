using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : ItemBase2D
{
    [SerializeField] int  HpUp= 1;
    public override void Activate()
    {
        FindObjectOfType<PlayerController>().AddHeart(HpUp);
    }
}
