using UnityEngine;

public class PlayheadMover : MonoBehaviour
{
    public Transform startPoint;

    public Transform endPoint;

    public void MovePlayhead(double playedFraction)
    {
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, (float)playedFraction);
    }
}
