using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Popup : MonoBehaviour {
	//public Texture pop_UI;
	public Image popImage;
	//bool IsPop=false;
	//Rect rec = new Rect(10,10,750,350);
	//GUIStyle style = new GUIStyle();
	// Use this for initialization
	void Start () {
		//_UI.enabled = true;
	}
	void OnTriggerEnter(Collider c)
	{
	//	IsPop = true;
		popImage.enabled = true;
	}
	void OnTriggerExit(Collider c)
	{
		popImage.enabled = false;
	//	IsPop = false;
	}
	void OnGUI()
	{
		//rec = new Rect(10,10,500,350);
		//if (IsPop)			GUI.Box (rec, pop_UI,style);
	}
}
