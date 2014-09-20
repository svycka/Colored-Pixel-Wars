using UnityEngine;
using System.Collections;

public class Raycasting : RaycastLogic {

	public bool disableTouches;
	private float zoomSpeed = 0.01f;
	private Vector2 currTouch1 = Vector2.zero,
					lastTouch1 = Vector2.zero,
					currTouch2 = Vector2.zero,
					lastTouch2 = Vector2.zero;
	private float currDist = 0.0f,
				  lastDist = 0.0f;
	private float touchTimer = 0.0f;
	private bool showHoldPanel = false;

    // Update is called once per frame
	void Update () {
		if(!disableTouches)
			CheckTouches ();
	}

	public override void OnTouchDown(){
		if (Input.touchCount == 1) {
			OneTouch(Input.GetTouch(0));
        }else if(Input.touchCount == 2){
			TwoTouch(Input.touches);
		}
	}

	private void OneTouch(Touch touch){
		if (touch.phase == TouchPhase.Began) {
			touchTimer = 0.0f;
			RaycastHit hit;
			Ray ray;
			ray = Camera.main.ScreenPointToRay(touch.position);
			
			if(Physics.Raycast(ray, out hit))
			{
				GameObject prevActiveTile = GameObject.FindGameObjectWithTag("activeTile");
				if(prevActiveTile != null){
					prevActiveTile.tag = "notActiveTile";
					prevActiveTile.renderer.material.color = new Color(0,0,1);
				}
				hit.collider.gameObject.tag = "activeTile";
				hit.collider.gameObject.renderer.material.color = new Color(0.5f,1,1);
			}
		}

		if (touch.phase == TouchPhase.Stationary && showHoldPanel == false) {
			touchTimer += touch.deltaTime;
			if(touchTimer > 1){
				showHoldPanel = true;
				Debug.Log ("getInfo()");
				//TODO: don't forget to set showHoldPanel = false when closing hold window
			}	
		}
	}

	private void TwoTouch(Touch[] touches){
		for (int i = 0; i < touches.Length; i++) {
			if (touches[i].phase == TouchPhase.Moved) {
				Zoom(touches);
				Move (touches);
			}
			if(touches[i].phase == TouchPhase.Stationary){
				Zoom (touches);
			}
		}
	}

	private void Zoom(Touch[] touches){
		zoomSpeed = 0.01f;

		currTouch1 = touches [0].position;
		lastTouch1 = currTouch1 - touches[0].deltaPosition;
		currTouch2 = touches [1].position;
		lastTouch2 = currTouch2 - touches[1].deltaPosition;

		currDist = Vector2.Distance (currTouch1, currTouch2);
		lastDist = Vector2.Distance (lastTouch1, lastTouch2);
		if(Camera.main.orthographicSize < 20)
			Camera.main.orthographicSize = Camera.main.orthographicSize - (currDist - lastDist) * zoomSpeed;
	}

	private void Move(Touch[] touches){
		float speed = 0.01f;
		float x = Camera.main.transform.position.x;
		float y = Camera.main.transform.position.y;
		float z = Camera.main.transform.position.z;
		Vector2 curr1 = touches [0].position;
		Vector2 curr2 = touches [1].position;
		Vector2 last1 = touches [0].position - touches[0].deltaPosition;
		Vector2 last2 = touches [1].position - touches[1].deltaPosition;
		float d1 = Vector2.Distance (curr1, last1);
		float d2 = Vector2.Distance (curr2, last2);
		Vector2 delta = new Vector2(0.0f, 0.0f);
		if(d1 > d2){
			delta.x = touches[0].deltaPosition.x;
			delta.y = touches[0].deltaPosition.y;
		}
		else{
			delta.x = touches[1].deltaPosition.x;
			delta.y = touches[1].deltaPosition.y;
		}
		Camera.main.transform.position = new Vector3(x - delta.x * speed, y - delta.y * speed, z);
    }
}
