using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGround : MonoBehaviour
{
    [SerializeField] private TextMesh ballCountText;
    [SerializeField] private Material road;
    [SerializeField] private float speed;
    private bool isFinish = false;
    private int ballCount;
    [SerializeField] private GameObject panelSuccess;
    [SerializeField] private GameObject panelFailure;

    void FixedUpdate()
    {
        if(ballCount >= 10 && !isFinish)
        {
            if (transform.position.y >= 0)
            {
                gameObject.GetComponent<MeshRenderer>().material = road;
                ballCount = 0;
                isFinish = true;
                panelSuccess.SetActive(true);
            }
            transform.Translate(new Vector3(0, Time.fixedDeltaTime * speed, 0));
        }
        else if(ballCount < 10 )
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == FinishTrigger.ballsTag)
        {
            ballCount++;
            ballCountText.text = ballCount.ToString();
            Destroy(collision.gameObject);
        }
    }

}
