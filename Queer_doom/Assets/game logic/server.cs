using UnityEngine;
using System.Collections;

public class server : MonoBehaviour {
public GameObject player;
	
	public static bool player_in;
	
	// Use this for initialization
	void Start () {
		
		player_in = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void OnTriggerEnter() {
		player_in = true;	
	}
	void OnTriggerExit() {
		player_in = false;	
	}
}
