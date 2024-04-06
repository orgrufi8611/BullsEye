using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] Transform shotOrigin;
    [SerializeField] GameLogic gameLogic;
    [SerializeField] float force;
    [SerializeField] Vector3 target;
    [SerializeField] GameObject arrowPrefub;
    
    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 2;
        line.SetWidth(0.1f, 0.2f);
        line.SetPosition(0, transform.position);
        target = transform.position + Vector3.right * 2;
        line.SetPosition(1, target);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLogic.canShoot)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                target = Vector3.RotateTowards(target, target + Vector3.up * Time.deltaTime, 1, 1);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                target = Vector3.RotateTowards(target, target + Vector3.down * Time.deltaTime, 1, 1);
            }
            line.SetPosition(1, target);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameLogic.arrowsLeft--;
                ShotArrow();
            }
        }
        else
        {
            line.SetPositions(new Vector3[] { transform.position, transform.position });
        }
    }

    void ShotArrow()
    {
        GameObject arrow = Instantiate(arrowPrefub, shotOrigin.position, Quaternion.identity);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),arrow.GetComponent<Collider>());
        arrow.GetComponent<ArrowScript>().gameLogic = gameLogic;
        arrow.GetComponent<ArrowScript>().Launch(target - transform.position, force);
        gameLogic.cam.GetComponent<CamScript>().ArrowShot(arrow.transform);
        gameLogic.canShoot = false;
    }
}
