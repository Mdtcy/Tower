using System;
using Assets.Scripts;
using HellTap.PoolKit;
using UnityEngine;
using Zenject;

public class SignalProcesser : IInitializable, IDisposable
{
    [Inject]
    readonly SignalBus       signalBus;

    private Pool floatingTextPool;

    public void Initialize()
    {
        signalBus.Subscribe<CollideSignal>(OnCollideSignal);
        signalBus.Subscribe<KillEnemySignal>(OnKillEnemy);
        floatingTextPool = PoolKit.GetPool(PoolId.FloatingTextPool);
    }

    public void Dispose()
    {
        signalBus.Unsubscribe<CollideSignal>(OnCollideSignal);
        signalBus.Unsubscribe<KillEnemySignal>(OnKillEnemy);

    }

    private void OnCollideSignal(CollideSignal collideSignal)
    {
        int damage = collideSignal.Projectile.damage;
        // 敌人受到伤害
        collideSignal.Enemy.TakeDamage(damage);

        // 子弹销毁
        collideSignal.Projectile.DestroySelf();

        // todo 子弹打到的特效
        var floatingTextTr = floatingTextPool.Spawn("FloatingText", collideSignal.Enemy.transform.position, Quaternion.identity, null);
        floatingTextTr.GetComponent<FloatingText>().SetupThenPlay(damage);
    }

    private void OnKillEnemy(KillEnemySignal killEnemySignal)
    {
        // Debug.Log($"VAR OnKillEnemy");
    }

}
