using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private FindTarget findTarget;

    private GameObject target;

    [Inject]
    readonly SignalBus signalBus;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        signalBus.Fire(new OnCollideSignal());
    }

    void Update()
    {
        // TODO 如果目标毁灭，中断，这里需要追加判断
        if (target == null)
        {
            target = findTarget.GetRandomTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
    }
}
