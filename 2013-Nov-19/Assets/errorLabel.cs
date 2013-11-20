using UnityEngine;
using System.Collections;

public class errorLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UILabel lbl = GetComponent<UILabel>();
		lbl.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		UILabel lbl = GetComponent<UILabel>();
		lbl.text = "" +NGUIParseTest.message;
	}
}
