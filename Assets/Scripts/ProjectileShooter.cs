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
    private GameObject pfbProjectile;

    #endregion

    private void Setup()
    {

    }

    public void Shoot()
    {
        // todo
        GameObject.Instantiate(pfbProjectile, transform.position, Quaternion.identity);
    }
}
