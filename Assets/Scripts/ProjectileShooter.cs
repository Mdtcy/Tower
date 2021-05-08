using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 通用的话得先分好目标
/// </summary>
public class ProjectileShooter : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private FindTarget findTarget;

    [SerializeField]
    private GameObject pfbProjectile;

    #endregion

    private void Setup()
    {

    }

    public void Shoot()
    {
        // todo
        var target = findTarget.GetRandomTarget();
        if (target != null)
        {
            Projectile projectile = Instantiate(pfbProjectile, transform.position, Quaternion.identity)
               .GetComponent<Projectile>();

            projectile?.Init(target?.GetComponent<Enemy>());
        }
    }
}
