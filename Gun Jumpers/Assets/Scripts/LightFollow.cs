using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    // The target marker.
    private GameObject target;
    private GameObject[] potentialTargets;
    private float distance = 0;

    void Update()
    {
        if(!target)
        {
            potentialTargets = GameObject.FindGameObjectsWithTag("Player");

            if (potentialTargets.Length != 0)
            {
                float currentLowest = Vector3.Distance(potentialTargets[0].transform.position, transform.position);
                target = potentialTargets[0];
                foreach (GameObject obj in potentialTargets)
                {
                    float currDistance = Vector3.Distance(obj.transform.position, transform.position);
                    if(currDistance < currentLowest)
                    {
                        target = obj;
                    }
                }
            }
        }

        if (target)
        {
            distance = Vector3.Distance(target.transform.position, transform.position);
            if(distance < 40)
            {
               transform.LookAt(target.transform);
            }
            if(distance >= 40)
            {
                target = null;
            }
        }
    }
}
