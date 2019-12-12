using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour
{
    public GameObject allSunday;
    public GameObject valentineDay;
    public GameObject blackFriday;
    public int totalScore;
    public float timeValue;
    public Text time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            timeValue = Mathf.Clamp(timeValue, 0, Mathf.Infinity);
            time.text = string.Format("{0:00.00}", time);
        }
    }
}
