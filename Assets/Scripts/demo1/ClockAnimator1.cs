using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ClockAnimator1 : MonoBehaviour
{

    // Use this for initialization
    private const float hoursToDegrees = 360f / 12f, minutesToDegrees = 360f / 60f, secondsToDegrees = 360f / 60f;
    [SerializeField]
    Transform hour, minute, second, alarm,timeShowTxt;
    [SerializeField]
    List<Text> listNum = new List<Text>();
    [SerializeField]
    Text txtHour, txtMinute, txtSecond;
    int aHour, aMinute, aSecond;

    TimeSpan timeAlarm = DateTime.Now.TimeOfDay;

    public bool analog;

    int currentChoose = 0;

    void Start()
    {
        Vector3 center = transform.position;
        for (int i = 0; i < listNum.Count; i++)
        {

            Vector3 pos = RandomCircle(center, 150, i * hoursToDegrees);
            listNum[i].transform.localPosition = pos;
            int num = i == 0 ? 12 : i;
            listNum[i].GetComponent<Text>().text = num.ToString();

        }
        TimeSpan timeNow = DateTime.Now.TimeOfDay;
        
        aHour = timeNow.Hours;
        aMinute = timeNow.Minutes +2;
        aSecond = timeNow.Seconds;
        setClockClick(0);
    }

    // Update is called once per frame
    void Update()
    {

        if (analog)
        {
            TimeSpan timespan = DateTime.Now.TimeOfDay;

            hour.localRotation = Quaternion.Euler(0, 0, (float)timespan.TotalHours * -hoursToDegrees);
            minute.localRotation = Quaternion.Euler(0, 0, (float)timespan.TotalMinutes * -minutesToDegrees);
            second.localRotation = Quaternion.Euler(0, 0, (float)timespan.TotalSeconds * -secondsToDegrees);

            Debug.Log(timespan);
            if(timespan.Hours == timeAlarm.Hours && timespan.Minutes == timeAlarm.Minutes && timespan.Seconds == timeAlarm.Seconds)
            {
                timeShowTxt.gameObject.SetActive(true);
            }
            
        }
        else
        {
            DateTime timeNow = DateTime.Now;

            hour.localRotation = Quaternion.Euler(0, 0, timeNow.Hour * -hoursToDegrees);
            minute.localRotation = Quaternion.Euler(0, 0, timeNow.Minute * -minutesToDegrees);
            second.localRotation = Quaternion.Euler(0, 0, timeNow.Second * -secondsToDegrees);
        }


    }

    Vector3 RandomCircle(Vector3 center, float radius, float a)
    {

        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
    public void setClockClick(int num)
    {
        if (currentChoose == 0)
        {
            aHour += num;
            aHour = aHour == 24 ? 0 : aHour;
            aHour = aHour < 0 ? 23 : aHour;
        }
        if (currentChoose == 1)
        {
            aMinute += num;
            aMinute = aMinute == 60 ? 0 : aMinute;
            aMinute = aMinute < 0 ? 59 : aMinute;
        }
        if (currentChoose == 2)
        {
            aSecond += num;
            aSecond = aSecond == 60 ? 0 : aSecond;
            aSecond = aSecond < 0 ? 59 : aSecond;
        }
        string sTime = aHour + ":" + aMinute + ":" + aSecond;
        timeAlarm = TimeSpan.Parse(sTime);
        setTimeAlarm();
    }
    public void clockElementClick(int num)
    {
        currentChoose = num;
    }
    void setTimeAlarm()
    {
        string h = timeAlarm.Hours >= 10 ? timeAlarm.Hours.ToString() : 0 + "" + timeAlarm.Hours.ToString();
        string m = timeAlarm.Minutes >= 10 ? timeAlarm.Minutes.ToString() : 0 + "" + timeAlarm.Minutes.ToString();
        string s = timeAlarm.Seconds >= 10 ? timeAlarm.Seconds.ToString() : 0 + "" + timeAlarm.Seconds.ToString();

        txtHour.text = h;
        txtMinute.text = m;
        txtSecond.text = s;

       

        alarm.localRotation = Quaternion.Euler(0, 0, (float)timeAlarm.TotalHours * -hoursToDegrees);
    }

}
