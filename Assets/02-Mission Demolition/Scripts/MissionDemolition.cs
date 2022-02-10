using UnityEngine;
using System.Collections;
using UnityEngine.UI; // a
public enum GameMode
{ // b
    idle,
    playing,
    levelEnd
}
public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S; // a private Singleton
    [Header("Set in Inspector")]
    public Text uitLevel; // The UIText_Level Text
    public Text uitShots; // The UIText_Shots Text
    public Text uitButton; // The Text on
    
public Vector3 castlePos; // The place to put
    
public GameObject[] castles; // An array of the
    
    [Header("Set Dynamically")]
public int level; // The current level
    public int levelMax; // The number of levels
    public int shotsTaken;
    public GameObject castle; // The current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot"; //
    
void Start()
    {
        S = this; // Define the Singleton
        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }
    void StartLevel()
    {
        
        if (castle != null)
        {
            Destroy(castle);
        }
        // Destroy old projectiles if they exist
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy( pTemp );
        }
        // Instantiate the new castle
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;
        // Reset the camera
        SwitchView("wShow Both");
        ProjectileLine.S.Clear();
        // Reset the goal
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }
    void UpdateGUI()
    {
        // Show the data in the GUITexts
        uitLevel.text = "Level: " + (level + 1) + "of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }
    void Update()
    {
        UpdateGUI();
        // Check for level end
        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            // Change mode to stop checking for level end
            mode = GameMode.levelEnd;
            // Zoom out
            SwitchView("Show Both");
            // Start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }
    }
    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }
    public void SwitchView(string eView = "")
    { // c
        if (eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;
            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;
            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }
    // Static method that allows code anywhere to increment
    
public static void ShotFired()
    { // d
        S.shotsTaken++;
    }
}
