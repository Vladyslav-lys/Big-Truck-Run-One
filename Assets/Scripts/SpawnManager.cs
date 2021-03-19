using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject roadPref;
    public GameObject smallObstaclePref;
    public GameObject bigObstaclePref;
    public GameObject tallObstaclePref;
    public GameObject longTallObstaclePref;

    public void CreateRoad()
    {
        Instantiate(roadPref, roadPref.transform.position, Quaternion.identity);
    }

    public void CreateObstacle()
    {
        Instantiate(smallObstaclePref, smallObstaclePref.transform.position, Quaternion.identity);
    }
}
