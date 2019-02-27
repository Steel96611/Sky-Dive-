using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public GameObject Hit; //地面にぶつかった時のエフェクト用のオブジェクトを入れる変数

    public GameObject[] result; //ゲーム終了時に生成するオブジェクトを入れる配列

    public static Vector2 this_pos; //このオブジェクトの座標を代入する変数

    public static int Life = 5; //ライフの値を示す変数

    public static bool goal; //ゴールしているかどうかを判断する変数

    bool spown; //オブジェクトを生成する際に使う

    // Use this for initialization
    void Start() { //ここで変数の初期化を行う

        Life = 5;

        goal = false;

        spown = true;
    }

    void Update() {

        this_pos = this.transform.position; //現在の座標を代入

        if (this_pos.x > (-8) && Input.GetKeyDown(KeyCode.LeftArrow)) //左へ移動
        {
            this_pos += new Vector2(-1, 0);

            this.GetComponent<Animator>().SetTrigger("Left");
        }

        if (this_pos.x < 8 && Input.GetKeyDown(KeyCode.RightArrow)) //右へ移動
        {
            this_pos += new Vector2(1, 0);

            this.GetComponent<Animator>().SetTrigger("Right");
        }

        this.transform.position = this_pos; //現在の座標に、移動先の値を代入

        if (BackgroundScript.time <= 2) //ゴール地点まで落ちる
        {

            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.025f);

        }

        if (goal)
        {

            if (Input.GetKeyDown(KeyCode.Space)) //タイトルへの移動
            {
                BackgroundScript.goal_flag = false;
                GoalScript.return_chack = true;
                SceneManager.LoadScene("TaitolScene");
            }


            if (spown)
            {
                Instantiate(result[0], new Vector2(0, 1), Quaternion.identity); //ゴール時のUIとなる表示を生成

                Instantiate(result[1], new Vector2(0, -1), Quaternion.identity);

                spown = false;
            }

        }

        if (Life <= 0) //ゲームオーバー時の処理
        {
            if (spown)
            {
                Instantiate(result[2], new Vector2(0, 1), Quaternion.identity);
                Instantiate(result[1], new Vector2(0, -1), Quaternion.identity);
                this.transform.position = new Vector2(0, 20);

                spown = false;

            }

            if (Input.GetKeyDown(KeyCode.Space)) //タイトルに戻ると同時に一部変数を初期化する
            {
                BackgroundScript.goal_flag = false;
                GoalScript.return_chack = true;
                SceneManager.LoadScene("TaitolScene");
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Bird")) //鳥のエネミーに当たった時
        {
            Instantiate(Hit, new Vector2(col.transform.position.x, col.transform.position.y), Quaternion.identity);

            Destroy(col.gameObject);

            Life--;
        }

        if (col.gameObject.name.Equals("Goal_Point")) //ゴールに当たった時
        {
            this.transform.position = new Vector2(col.transform.position.x, this.transform.position.y);

            goal = true;
            this.GetComponent<Animator>().SetTrigger("end");

        }

        if (col.gameObject.name.Equals("Grand")) //地面に当たった時
        {
            Instantiate(Hit, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);

            Life = 0;

        }

    }
}
