using UnityEngine;
using System.Collections;
public class Slingshot : MonoBehaviour
{
    [Header("Setin Inspector")]
    public GameObject prefabProjectile;

    [Header("Set Dynamically")]
    // a
    public GameObject launchPoint;
    public
    Vector3 launchPos; //b
    public GameObject
    projectile; // b
    public bool
    aimingMode;

    void Awake()
    {
        Transform launchPointTrans =
        transform.Find("LaunchPoint"); // a
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);

        launchPos = launchPointTrans.position; // c

    }
    void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true); // b
    }
    void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false); // b
    }
    void OnMouseDown()
    {
        aimingMode = true;
        // Instantiate a Projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        // Start it at the launchPoint
        projectile.transform.position = launchPos;
        // Set it to isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

}