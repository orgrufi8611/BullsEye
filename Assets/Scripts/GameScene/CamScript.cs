using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    Vector3 initPos;
    Quaternion initRot;
    Transform followTarget;
    bool follow;
    // Start is called before the first frame update
    void Start()
    {
        follow = false;
        initPos = transform.position;
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!follow)
        {
            transform.position = initPos;
            transform.rotation = initRot;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,90,0);
            transform.position = followTarget.position + new Vector3(-2,0.1f,0);
        }
    }

    public void ArrowShot(Transform arrow) 
    {
        follow = true;
        followTarget = arrow;
    }
    public void ResetCamera()
    {
        follow = false;
        followTarget = null;
    }
}
