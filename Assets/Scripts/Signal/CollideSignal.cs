using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CollideSignal
{
    public Projectile Projectile { get; }
    public Enemy      Enemy      { get; }
    public CollideSignal(Projectile projectile, Enemy enemy)
    {
        Projectile = projectile;
        Enemy      = enemy;
    }
}
