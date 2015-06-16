using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {
	
	public Transform hero;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	GetComponent<NavMeshAgent>().destination = new Vector3 (hero.position.x + 3 , hero.position.y , hero.position.z );
	}
}
