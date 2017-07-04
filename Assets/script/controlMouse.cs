using UnityEngine;
using System.Collections;

public class controlMouse : MonoBehaviour {

	public Vector3 target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LookAtCursor ();
	}

	void LookAtCursor (){
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		//Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		//Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
        Ray  ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//Ray ray1 =Camera.
		if (Physics.Raycast (ray, out hit)) {
			target = hit.point;
		}

		transform.LookAt (target);
	}
}
