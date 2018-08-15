using UnityEngine;
using System.Collections;
using System;

public class ClockDigital : MonoBehaviour 
{
	private void OnGUI () 
	{

		DateTime time = DateTime.Now;
		string hour = LeadingZero( time.Hour%12 );//dong ho 12 so
	//	string hour = LeadingZero( time.Hour );//dong ho 24so
		string minute = LeadingZero( time.Minute );
		string second = LeadingZero( time.Second );
		GUI.Box(new Rect (5, 5, 100, 25), hour + ":" + minute + ":" +  second);    
	}

	// given an integer, return a 2-character string
	// adding a leading zero if required
	private string LeadingZero(int n)
	{
		return n.ToString().PadLeft(2, '0');
	}
}