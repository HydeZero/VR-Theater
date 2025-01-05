using UnityEngine;

public class PlayheadMover : MonoBehaviour
{
    public Transform startPoint;

    public Transform endPoint;
    // see https://www.youtube.com/watch?v=k2jhzISLfSY for info on this code
    public void MovePlayhead(double playedFraction)
    {
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, (float)playedFraction);
    }
}
