using UnityEngine;
using System.Collections;

public class sql_hack : MonoBehaviour {
	public GUITexture surface;
	public GUITexture finger_print_logo;
	public GUITexture sql_hack_logo;
	public GUITexture sql_main;
	public GUITexture surface_error;
	public GUITexture error_back;
	public GUITexture start_btn;
	public GUITexture exit_btn;
	public bool open;

	// Use this for initialization
	void Start () {
	
		sql_hack_logo.enabled = false;
		sql_main.enabled = false;
		open = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		// f button
		if(Input.GetKeyDown("f") && open == false ) {
			
			sql_hack_logo.enabled = true;
			open = true;
			
		}
		
		else if (Input.GetKeyDown("f") && open == true) {
			
			sql_hack_logo.enabled = false;
			open = false;
		}
		
		if(Input.GetMouseButton(0) && sql_hack_logo.HitTest(Input.mousePosition) && open == true && server.player_in == false )

		{
			
			surface_error.enabled = true;
   			error_back.enabled = true;

		}
		// sql main game area
		if(Input.GetMouseButton(0) && sql_hack_logo.HitTest(Input.mousePosition) && open == true && server.player_in == true)

		{
			sql_hack_logo.enabled = false;
			finger_print_logo.enabled = false;
			sql_main.enabled = true;
			start_btn.enabled = true;
			exit_btn.enabled = true;

		}
		
		if(Input.GetMouseButton(0) && exit_btn.HitTest(Input.mousePosition) && open == true && server.player_in == true) {
		
			sql_main.enabled = false;
			start_btn.enabled = false;
			exit_btn.enabled = false;
			surface.enabled = false;
			sql_hack_logo.enabled = true;
			
		}
	}
}
