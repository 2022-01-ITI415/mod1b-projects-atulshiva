using UnityEngine;
using System.Collections;
public class FollowCam : MonoBehaviour
{
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;
    static public GameObject POI; // The static point ofinterest // a
    [Header("Set Dynamically")]
    public float camZ; // The desired Z pos of thecamera

    void Awake()
    {
        camZ = this.transform.position.z;
    }
    void FixedUpdate()
    {
        // if there's only one line following an if, it doesn'tneed braces
        if (POI == null) return; // return if there is nopoi // b
                                 // Get the position of the poi
        Vector3 destination = POI.transform.position;
       
        destination = Vector3.Lerp(transform.position, destination,
easing);

        // Force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        // Set the camera to the destination
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}