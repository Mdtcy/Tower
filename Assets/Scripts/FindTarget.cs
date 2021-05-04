using Assets.Scripts;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

public class FindTarget : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private GameObjectSet targetSet;

    #endregion

    public GameObject GetNearestTarget()
    {
        if (targetSet.Items.IsNullOrEmpty())
        {
            return null;
        }

        float      min = float.MaxValue;
        GameObject go  = null;

        for (int index = 0; index < targetSet.Items.Count; index++)
        {
            float distance = Vector3.Distance(targetSet.Items[index].transform.position, transform.position);
            if (distance < min)
            {
                min = distance;
                go  = targetSet.Items[index];
            }
        }

        return go;
    }

    public GameObject GetRandomTarget()
    {
        if (targetSet.Items.IsNullOrEmpty())
        {
            return null;
        }

        return targetSet.Items.GetRandom();
    }
}