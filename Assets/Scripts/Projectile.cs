using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    public int damage;

    private Enemy targetEnemy;

    [Inject]
    readonly SignalBus signalBus;

    public void Init(Enemy enemy)
    {
        targetEnemy = enemy;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.GetComponent<Enemy>()!=null)
        {
            signalBus.Fire(new CollideSignal(this, obj.GetComponent<Enemy>()));
        }
    }

    private Vector3 lastDirection;
    void Update()
    {
        // TODO 如果目标毁灭，中断，这里需要追加判断
        if (targetEnemy == null || targetEnemy.IsDie)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position+ lastDirection *100, speed);
        }
        else
        {
            lastDirection      = (targetEnemy.transform.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, speed);
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
