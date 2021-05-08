using System;
using Assets.Scripts;
using UnityEngine;
using Zenject;

public class SignalProcesser : IInitializable, IDisposable
{
    [Inject]
    readonly SignalBus       signalBus;


    public void Initialize()
    {
        signalBus.Subscribe<CollideSignal>(OnCollideSignal);
        signalBus.Subscribe<KillEnemySignal>(OnKillEnemy);
    }

    public void Dispose()
    {
        signalBus.Unsubscribe<CollideSignal>(OnCollideSignal);
        signalBus.Unsubscribe<KillEnemySignal>(OnKillEnemy);

    }

    private void OnCollideSignal(CollideSignal collideSignal)
    {
        // 敌人受到伤害
        collideSignal.Enemy.TakeDamage(collideSignal.Projectile.damage);

        // 子弹销毁
        collideSignal.Projectile.DestroySelf();

        // todo 子弹打到的特效
    }

    private void OnKillEnemy(KillEnemySignal killEnemySignal)
    {
        Debug.Log($"VAR OnKillEnemy");
    }

}
