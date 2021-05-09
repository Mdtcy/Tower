using System;
using System.Collections;
using BeauRoutine;
using HellTap.PoolKit;
using MoreMountains.Feedbacks;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    private MMFeedbacks mmFeedbacks;

    [SerializeField]
    private TextMesh textMesh;

    [SerializeField]
    private float duration;


    Routine hideRoutine = Routine.Null;


    private Pool floatingTextPool;

    private void Awake()
    {
        floatingTextPool = PoolKit.GetPool(PoolId.FloatingTextPool);
    }

    public void SetupThenPlay(int damage)
    {
        textMesh.text = damage.ToString();
        mmFeedbacks.PlayFeedbacks();
        hideRoutine = Routine.Start(this, IAutoHide());
    }

    private IEnumerator IAutoHide()
    {
        yield return Routine.WaitSeconds(duration);
        floatingTextPool.Despawn(gameObject);
    }


}
