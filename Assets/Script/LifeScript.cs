using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour {

    public int type; //何番目の配置なのかを示す
	
	// Update is called once per frame
	void Update () {
		
        if(PlayerScript.Life < type) //ライフが自分の配置の値以下の場合削除する
        {
            Destroy(this.gameObject);
        }

	}
}
