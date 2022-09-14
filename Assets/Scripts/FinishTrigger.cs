using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    public static int level = 1;
    public static string ballsTag = "balls1";
    public static bool isLevelOver = false;
    private int i = 0;

    //private void FixedUpdate()
    //{
        
    //    if(PickerMovement.timee > 0.0f && isLevelOver)
    //    { 
    //        PickerMovement.timee = PickerMovement.timee - Time.fixedDeltaTime;
    //        if (PickerMovement.timee <= 0.0f)
    //        {      
    //            isLevelOver = false;
    //        }
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(isLevelOver);
        Debug.Log(PickerMovement.timee);
        Debug.Log(PickerMovement.moveSpeed);
        if (other.tag == "picker" && !isLevelOver)
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag(ballsTag);
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
            }
            i++;
            PickerMovement.moveSpeed = 0.0f;
        }
    }

    public void nextLevel()
    {
        isLevelOver = true;
        PickerMovement.timee = 5.0f;
        PickerMovement.moveSpeed = 8.0f;
        GameObject.Find("PanelOverLevelSuccess").SetActive(false);
        level += 1;
        levelText.text = level.ToString();
        ballsTag = "balls";
        ballsTag = ballsTag + level.ToString();

    }
    
    public void replayLevel()
    {

    }
}
