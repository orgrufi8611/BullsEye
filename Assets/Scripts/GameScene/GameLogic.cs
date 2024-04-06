using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI arrowLeft;

    public int arrowsLeft;
    public Camera cam;
    public bool canShoot;
    public float waitTime;
    int points;
    
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        points = 0;
        arrowsLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + points.ToString();
        arrowLeft.text = "Arrows: " + arrowsLeft.ToString();
        if(arrowsLeft <= 0)
        {
            canShoot = false;
            GameOver();
        }
    }

    void GameOver()
    {
        
    }

    public void TargetHit(int add)
    {
        points += add;
        StartCoroutine(ResetCam());
    }

    IEnumerator ResetCam()
    {
        yield return new WaitForSeconds(waitTime);
        cam.GetComponent<CamScript>().ResetCamera();
        canShoot = true;
    }
}
