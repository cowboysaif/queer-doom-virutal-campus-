using UnityEngine;
using System.Collections;



public class surface_open : MonoBehaviour {
	
	public GUITexture surface;
	public GUITexture finger_print_logo;
	public GUITexture surface_error;
	public GUITexture error_back;
	public GUITexture fp_main;
	
	
	public GUITexture start_btn;
	
	public GUITexture exit_btn;
	public GUITexture box;
	public GUITexture fp;
	public GUIText locked;
	public GUIText terminal;
	public GUIText terminal1;
	public GUIText terminal2;
	public static bool open;
	public static bool start;
	public static float resume_time;
	public static float direction_time;
	public static int num;
	public static int score;
	public static int real_score;
	
	void Start () {

    
	surface.enabled = false;
	finger_print_logo.enabled = false;
	surface_error.enabled = false;
	error_back.enabled = false;
	fp_main.enabled = false;
	start_btn.enabled = false;
	
	
	exit_btn.enabled = false;
	box.enabled = false;
	locked.enabled = false;
	terminal.enabled = false;
	terminal1.enabled = false;
	terminal2.enabled = false;
	fp.enabled = false;
	open = false;
	start = false;
	score = 0;
	real_score = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// F key
		if(Input.GetKeyDown("f") && open == false ) {
			
			surface.enabled = true;
			finger_print_logo.enabled = true;
			open = true;
			
		}
		
		else if (Input.GetKeyDown("f") && open == true) {
			
			surface.enabled = false;
			finger_print_logo.enabled = false;
			open = false;
		}

		
		//enable /disable character movement
		if ( open == true ) {

			CharacterMotor motor = GetComponent<CharacterMotor>();
			motor.enabled = false;
		}
		
		else {
			CharacterMotor motor = GetComponent<CharacterMotor>();
			motor.enabled = true;
		}
		
		// Fingerprint error area
		if(Input.GetMouseButton(0) && finger_print_logo.HitTest(Input.mousePosition) && open == true && server_door.player_in == false )

		{
			
			surface_error.enabled = true;
   			error_back.enabled = true;

		}
		// fp main game area
		if(Input.GetMouseButton(0) && finger_print_logo.HitTest(Input.mousePosition) && open == true && server_door.player_in == true)

		{
			
			fp_main.enabled = true;
			start_btn.enabled = true;
			
			
			exit_btn.enabled = true;

		}
		
		// error back
		
		if(Input.GetMouseButton(0) && error_back.HitTest(Input.mousePosition) && error_back.enabled == true )

		{
			
			surface.enabled = true;
			surface_error.enabled = false;
			error_back.enabled = false;

			

		}
		
		// back from fp main (exit_btn)
		
		if(Input.GetMouseButton(0) && exit_btn.HitTest(Input.mousePosition) && open == true && server_door.player_in == true) {
		
			fp_main.enabled = false;
			start_btn.enabled = false;
			exit_btn.enabled = false;
			surface.enabled = false;
			finger_print_logo.enabled = false;
				fp_main.enabled = false;
	start_btn.enabled = false;
	
	fp.enabled = false;
	exit_btn.enabled = false;
	box.enabled = false;
	locked.enabled = false;
	terminal.enabled = false;
	terminal1.enabled = false;
	terminal2.enabled = false;
			TimerScript.reset();
		}
		
		// start button is hit , game on !
		
		if(Input.GetMouseButton(0) && start_btn.HitTest(Input.mousePosition) && open == true && server_door.player_in == true) {
			
			start_btn.enabled = false;
			
			
			TimerScript.start(300);
			box.enabled = true;
			start = true;
			direction_time = TimerScript.timer;
				locked.enabled = true;
		terminal.enabled = true;
		terminal1.enabled = true;
		terminal2.enabled = true;
			fp.enabled = true;
			
		}
		
		// resume button
		
		if(Input.GetMouseButton(0) && start_btn.HitTest(Input.mousePosition) && open == true && server_door.player_in == true) {
			//Doesn't have to be resumed !!
			//TimerScript.started = false;
			
		}
		
		// w a s d movement
		
		if (start == true ) {
			
	   	if (Input.GetKey("w")) {
			
			if (box.guiTexture.pixelInset.y + 5 <= 7.9 ) {
			
			box.guiTexture.pixelInset = new Rect ( box.guiTexture.pixelInset.x  , box.guiTexture.pixelInset.y + 5,0,0 );
			
			}
		}
			
		if (Input.GetKey("a")) {
				
			if (box.guiTexture.pixelInset.x - 5 >= -15 ) {
			
			box.guiTexture.pixelInset = new Rect ( box.guiTexture.pixelInset.x - 5 , box.guiTexture.pixelInset.y ,0,0 );
				}
		}
			
		if (Input.GetKey("s")) {
				
			if (box.guiTexture.pixelInset.y - 5 >= -60.2 ) {
					
			box.guiTexture.pixelInset = new Rect ( box.guiTexture.pixelInset.x , box.guiTexture.pixelInset.y - 5 ,0,0 );
			
				}
		}
			
		if (Input.GetKey("d")) {
				
				if (box.guiTexture.pixelInset.x + 5 <= 199 ) {
			
			box.guiTexture.pixelInset = new Rect ( box.guiTexture.pixelInset.x +5 , box.guiTexture.pixelInset.y  ,0,0 );
				}	
		}
			
		//fp movement
			//Debug.Log(direction_time - TimerScript.displaySeconds);
		if ( direction_time - TimerScript.timer >= .5 ) {
				
				if ( box.guiTexture.pixelInset.x - fp.guiTexture.pixelInset.x <= 130 && box.guiTexture.pixelInset.x - fp.guiTexture.pixelInset.x >= 124 && box.guiTexture.pixelInset.y - fp.guiTexture.pixelInset.y < -20 && box.guiTexture.pixelInset.y - fp.guiTexture.pixelInset.y > -40 ) {
					score = score + 10;
					terminal.material.color = Color.yellow;
					terminal.text = "root@admin: target locking...";
					if ( score > 360 ) {
						locked.enabled = true;
						real_score = real_score + 20;
						locked.text = real_score + " % locked";
						score = 0;
					}
					
					
				}
				
				else {
					terminal.material.color = Color.red;
					terminal.text = "root@admin: target going too far...";	
				}
				bool done = false;
				int move = 3;
				while( done == false ) {
					
				System.Random r = new System.Random();
			    num = r.Next(1,5);
				
				
				if ( ( num == 1 ||  num + 1 == 1 ) && fp.guiTexture.pixelInset.y + move <= 41.99) {
					done = true;
					fp.guiTexture.pixelInset = new Rect ( fp.guiTexture.pixelInset.x  , fp.guiTexture.pixelInset.y + move,0,0 );
				}
				 if ( ( num == 2 ||  num + 1 == 2 ) && fp.guiTexture.pixelInset.x - move >= -141.99) {
					done = true;
					fp.guiTexture.pixelInset = new Rect ( fp.guiTexture.pixelInset.x - move , fp.guiTexture.pixelInset.y ,0,0 );
				}
				 if ( ( num == 3 ||  num + 1 ==3 ) && fp.guiTexture.pixelInset.y - move >= -33.4 ) {
					done = true;
						
					fp.guiTexture.pixelInset = new Rect ( fp.guiTexture.pixelInset.x , fp.guiTexture.pixelInset.y - move ,0,0 );
				}
				 if ( ( num == 4 ||  num + 1 == 4 ) && fp.guiTexture.pixelInset.x + move <= 74.98) {
					done = true;
					
					fp.guiTexture.pixelInset = new Rect ( fp.guiTexture.pixelInset.x +move , fp.guiTexture.pixelInset.y  ,0,0 );
				}
				direction_time = TimerScript.timer;
				 
				}
			}
		
		else {
			
				int move = 6;
				if ( ( num == 1 ||  num + 1 == 1 ) && fp.guiTexture.pixelInset.y + move <= 41.99) {
				
					fp.guiTexture.pixelInset = new Rect ( fp.guiTexture.pixelInset.x  , fp.guiTexture.pixelInset.y + move,0,0 );
				}
				 if ( ( num == 2 ||  num + 1 == 2 ) && fp.guiTexture.pixelInset.x - move >= -141.99) {
					fp.guiTexture.pixelInset = new Rect ( fp.guiTexture.pixelInset.x - move , fp.guiTexture.pixelInset.y ,0,0 );
				}
				 if ( ( num == 3 ||  num + 1 == 3 ) && fp.guiTexture.pixelInset.y - move >= -33.4 ) {
					fp.guiTexture.pixelInset = new Rect ( fp.guiTexture.pixelInset.x , fp.guiTexture.pixelInset.y - move ,0,0 );
				}
				 if ( ( num == 4  ||  num + 1 ==4 ) && fp.guiTexture.pixelInset.x + move <= 74.98) {
					fp.guiTexture.pixelInset = new Rect ( fp.guiTexture.pixelInset.x +move , fp.guiTexture.pixelInset.y  ,0,0 );
				}
				
			}
		
			
		}
		
	}
	
	
}