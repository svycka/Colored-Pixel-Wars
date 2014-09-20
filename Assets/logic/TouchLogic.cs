using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {

	public void CheckTouches () {

		if (Input.touches.Length <= 0) {
			OnNoTouches();
			//if there are no touches on screen
		} else {
			//if there are touches on screen
			for(int i = 0; i < Input.touchCount; i++){
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					if(Input.GetTouch(i).phase == TouchPhase.Began){
						OnTouchDown();
						//this.SendMessage('OnTouchDown');
						//Debug.Log ('Touch began');
					}
					if(Input.GetTouch(i).phase == TouchPhase.Ended){
						OnTouchUp();
						//this.SendMessage('OnTouchUp');
						//Debug.Log ('Touch ended');
					}
				}
			}
		}
	}

	//override with public override void FunctionName(){}
	public virtual void OnTouchDown(){}
	public virtual void OnTouchUp(){}
	public virtual void OnNoTouches(){}

}
