using UnityEngine;
using System.Collections;

public class RaycastLogic : MonoBehaviour {



	public void CheckTouches() {
		if (Input.touches.Length <= 0) {
			OnNoTouches();
			//if there are no touches on screen
		} else {
			//if there are touches on screen
			for(int i = 0; i < Input.touchCount; i++){
					OnTouchDown();
            }
        }

	}

	public virtual void OnTouchDown(){}
	public virtual void OnNoTouches(){}
    

}
