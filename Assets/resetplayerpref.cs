using UnityEngine;
using System.Collections;

public class resetplayerpref : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	PlayerPrefs.SetInt("UserLoggedIn", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
