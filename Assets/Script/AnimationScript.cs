using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    public int time; //このオブジェクトを削除するまでの時間

	// Use this for initialization
	void Start () {

        Destroy(this.gameObject, time);

	}
	
}
