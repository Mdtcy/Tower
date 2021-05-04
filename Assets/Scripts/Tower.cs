using System.Collections;
using Assets.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class Tower : MonoBehaviour
{
    #region Fields

    public float cd;

    [Inject(Id = ZenjectId.TowerSet)]
    private GameObjectSet TowerSet;

    [SerializeField]
    private ProjectileShooter projectileShooter;

    #endregion

    private void Start()
    {
        StartCoroutine(IAttack());
        TowerSet.AddToList(this.gameObject);
    }

    private void Attack()
    {
        projectileShooter.Shoot();
    }

    IEnumerator IAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(cd);
            Attack();
        }
    }
}
