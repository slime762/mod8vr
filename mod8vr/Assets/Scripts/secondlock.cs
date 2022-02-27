using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Vector3 getaimpoint(Vector3[] points,int locktime) {
        Vector3 velocity1,velocity2, acceleration;

        if (locktime == 3) {
            velocity1 = points[0] - points[1];
            velocity2 = points[1] - points[2];
            acceleration = velocity1 - velocity2;
            return (acceleration  + velocity1)/Time.fixedDeltaTime ;
        }
        else if (locktime == 2) {
            velocity1 = points[0] - points[1];
            return velocity1 / Time.fixedDeltaTime;
        }
        else
            return points[0];
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
