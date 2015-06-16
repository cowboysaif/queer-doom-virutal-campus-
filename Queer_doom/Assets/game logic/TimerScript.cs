    using UnityEngine;
	using System.Collections;

	public class TimerScript : MonoBehaviour {

   	string timetext;
	public static float Timeleft;
	public static float restSeconds;
	public static int roundedRestSeconds;
	public static float displaySeconds;
	public static float displayMinutes;
	public  GUIText t;
	public static bool time_finished;
	public static bool started;
	public static bool show;

    // Use this for initialization
     
    public static float timer = 0.0f;
	static float timerMax = 3.0f;
	void Start()
	{
		t.enabled = false;
		
		//time_finished = false;
		//started = false;
		
	}
	public static void countdown() {
		
		timer = timerMax ;	
	}
	
	public static void start( float s_time ) {
		
		time_finished = false;
		started = true;
		timerMax = s_time;
		show = true;
		countdown();
		
	}
	
	public static void reset() {
		show = false;
	}
	
	public static float get_time() {
		return timer;
	}
	
	void Update()
	{
	
	
		if ( started == true && time_finished == false ) {
		
		t.enabled = true;
		
		timer -= Time.deltaTime;
 	
 
		restSeconds = timer;
 
		roundedRestSeconds=Mathf.CeilToInt(restSeconds);
		displaySeconds = roundedRestSeconds % 60;
		displayMinutes = (roundedRestSeconds / 60)%60;
 	
		timetext = (displayMinutes.ToString()+":");
		if (displaySeconds > 9)
		{
			timetext = timetext + displaySeconds.ToString();
		}
		else
		{
			timetext = timetext + "0" + displaySeconds.ToString();
		}
		
		if (timer < 0)
		{
			time_finished = true;
				
		}
		
			if (show == true ) {
				t.enabled = true;
		if (   (int)timer % 2 == 0 && timer < 30  ) {
				t.material.color = Color.red;
				t.text = timetext;
		}
	    else {
				t.material.color = Color.white;
				t.text = timetext;
		}
			}
			else {
				t.enabled = false;	
			}
		
		}
		
	}
}