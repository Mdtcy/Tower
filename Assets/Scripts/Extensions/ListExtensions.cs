using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

public static class ListExtensions
{
    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        T temporary = list[i];
        list[i] = list[j];
        list[j] = temporary;
    }

    public static T GetRandom<T>(this IList<T> list)
    {
        // todo 为空时可能有错
        return list[Random.Range(0, list.Count)];
    }

}
