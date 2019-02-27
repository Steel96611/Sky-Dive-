using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

    public GameObject hit; //衝突時のアニメーション用オブジェクトを代入する変数

    public Vector2 pos; //このオブジェクトの座標を代入する変数

    public bool Left; //画面左に行くかどうかを示す変数

    public float Speed; //画面下から上に動く際の移動量

    void Start()
    {
        //ここで変数の値を初期化する

        pos = this.transform.position;

        pos.y = Random.Range(-15.0f, -10.0f);

        this.transform.position = pos;

        Left = true;

        Speed = 0.04f;
    }

    // Update is called once per frame
    void Update () {

        pos = this.transform.position; //現在の座標を代入

        if (Left) //trueなら画面左、falseなら画面右を画面下から移動する
        {
            pos.x = -6;
        }
        else
        {
            pos.x = 6;
        }

        pos.y += Speed;

        if(pos.y >= 10) //一定の高さまで移動したので画面下に移動する
        {
            pos.y = Random.Range(-15.0f, -10.0f);

            if (Left)
            {
                Left = false;
            }
            else
            {
                Left = true;
            }
        }

        if (BackgroundScript.goal_flag)
        {
            pos.x = -20;
        }

        this.transform.position = pos;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player") && !GoalScript.goal_chack)
        {
            Instantiate(hit, pos, Quaternion.identity);

            PlayerScript.Life = PlayerScript.Life - 2;

            pos.y = Random.Range(-15.0f, -10.0f);

            this.transform.position = pos;

        }

    }

}
