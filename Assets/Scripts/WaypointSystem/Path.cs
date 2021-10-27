using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    // Start is called before the first frame update
    void Start()
    {
        // StartPath
        //EndPath
        //NextPath


        //Lookat Waypoint
        //Move towards waypoint
        //when at the waypoint change waypoint
            //At the last? --> pathComplete()

        //GetPath
            //Take the posistion from the waypoint class

        //pathComplete
            //Destroy target & - Health player
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Waypoint GetWaypoint()
    {
        return _waypoints[0];
    }

    public Waypoint GetEndPath()
    {
        return _waypoints[_waypoints.Length - 1];
    }

    public Waypoint NextWaypoint(Waypoint _currentWaypoint)
    {
        for (int i = 0; i < _waypoints.Length; i++)
        {
            if (_waypoints[i] == _currentWaypoint)
            {
                return _waypoints[i + 1];
            }
            
        }
        return null;
    }
}
