using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utils
{

    public static bool bossTime;
    /// <summary>
    /// Finds closest object to given position that has given tag. If maxDistance is set, ignores objects whose
    /// distance to position is bigger than maxDistance.
    /// </summary>
    public static GameObject FindClosestTo(Vector3 position, string tag, float maxDistance = float.MaxValue)
    {
        GameObject[] candidates = GameObject.FindGameObjectsWithTag(tag);
        if (candidates.Length == 0)
            return null;

        GameObject closest = null;
        float closestDistance = maxDistance;  // If there aren't any candidates closer than maxDistance, `closest` will stay null

        foreach (GameObject obj in candidates)
        {
            float dist = Vector2.SqrMagnitude(obj.transform.position - position);
            if (dist < closestDistance)
            {
                closest = obj;
                closestDistance = dist;
            }
        }

        return closest;
    }


}
