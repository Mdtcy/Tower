using Assets.Scripts;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    #region Fields

    [Inject(Id = ZenjectId.EnemySet)]
    private GameObjectSet EnemySet;

    [SerializeField]
    private FindTarget findTarget;

    [SerializeField]
    private float speed;

    private GameObject targetTower;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        EnemySet.AddToList(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO 如果炮塔毁灭，中断，这里需要追加判断
        if (targetTower == null)
        {
            targetTower = findTarget.GetRandomTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetTower.transform.position, speed);
    }
}
