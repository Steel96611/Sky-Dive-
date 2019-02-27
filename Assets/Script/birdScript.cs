using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour {

    Vector2 this_pos; //このオブジェクトの座標を代入する変数
    Vector2 move_pos; //移動先の座標を示す変数
    float random_x; //画面下に戻る際の座標のx軸
    float random_y; //画面下に戻る際の座標のy軸
    float plus;  //一回の移動量のx軸の値
    float speed; //一回の移動量のy軸の値

    // Use this for initialization
    void Start () {

        //ここで変数の値を初期化する

        random_x = Random.Range(-3, 3);
        random_y = Random.Range(-15.0f, -10.0f);
        move_pos = new Vector2(random_x * (-1), 10);
        plus = move_pos.x / 100;
        speed = 0.03f;
        this.transform.position =  new Vector2(random_x, random_y);
    }
	
	// Update is called once per frame
	void Update () {

        this_pos = this.transform.position; //現在の座標を代入

        //GetComponent<Rigidbody2D>().velocity += new Vector2(plus, speed);
        this_pos += new Vector2(plus, speed);
        this.transform.position = this_pos;

        if(this.transform.position.y >= 10) Destroy(this.gameObject);

	}

}
