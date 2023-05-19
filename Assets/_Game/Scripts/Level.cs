using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    [SerializeField] Transform bottomLeftPoint, topRightPoint;

    public int MaxActiveBotLimit = GameConstant.Level.DEFAULT_ACTIVE_BOT_AMOUNT;
    public int TotalCharacterAmount = GameConstant.Level.DEFAULT_CHARACTER_AMOUNT;
    public List<Transform> SpawnPoints;

    public Vector3? NavMeshSamplePosition(Vector3 sourcePosition)
    {
        if (NavMesh.SamplePosition(sourcePosition, out NavMeshHit hit, float.PositiveInfinity, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return null;
    }
    public Vector3 RandomPosition()
    {
        Vector3 randPoint =
            Random.Range(bottomLeftPoint.position.x, topRightPoint.position.x) * Vector3.right +
            Random.Range(bottomLeftPoint.position.z, topRightPoint.position.z) * Vector3.forward + 10 * Vector3.up;
        Vector3? result = NavMeshSamplePosition(randPoint);
        return result == null? RandomPosition() : result.Value;
    }
}
