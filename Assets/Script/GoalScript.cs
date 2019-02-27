using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    public static bool goal_chack;   //ゴールしているかどうかの判定
    public static bool return_chack; //初期化のために必要な変数

	// Use this for initialization
	void Start () {

        //ここで変数の値を初期化する

        goal_chack = false;

        return_chack = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.y <= -4.3f) //まだゴールしていないので、スクロールに合わせてこのオブジェクトを移動させる
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.01f);
        }

        if(this.transform.position.y >= 0) //ゴールしたという判定をする
        {
            goal_chack = true;
            PlayerScript.goal = true;
            this.transform.position = new Vector2(0, 0);
        }

        if (return_chack) //タイトル画面に戻るときに変数の値を初期化し、このオブジェクトを削除する
        {
            goal_chack = false;
            Destroy(this.gameObject);
        }

    }
}
