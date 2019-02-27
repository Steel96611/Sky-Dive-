using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundScript : MonoBehaviour {

    public GameObject[] enemy; //生成するエネミーを入れる変数

    public GameObject[] goal; //ゴールのPrehubを入れる変数

    public GameObject[] cloud;

    public static bool goal_flag; //プレイヤーがゴールしているかどうか

    public static float scrolcnt; //スクロールするたびに、その回数をカウントしている

    public static float time; //残り時間を示す値

    public static int speed; //スクロールする速度を示す値

    bool Spown_flag;

    int Spown_Rag;

    void Start()
    {
        //ここで変数の値を初期化する

        goal_flag = false;

        scrolcnt = 50;

        time = 30;

        speed = 19;

        Spown_flag = false;

        Spown_Rag = 0;

        int spown_cloud = Random.Range(1, 5);

        for (int c = 0; c <= spown_cloud; c++)
        {
            int Random_x = Random.Range(-8, 8);
            int Random_y = Random.Range(-5, 20);

            Instantiate(cloud[1], new Vector2(Random_x, Random_y), Quaternion.identity);
        }

    }

    void Update()
    {
        int i;

        if (Spown_flag && time >= 7)
        {
            Spown_flag = false;

            int spown = Random.Range(1, 3);

            for (i = 0; i <= spown; i++)
            {
                GameObject Bird = Instantiate(enemy[0], new Vector2(0, -3), Quaternion.identity);
                Bird.name = "Bird";
            }

            if (spown == 1) Instantiate(cloud[0], new Vector2(0, -10), Quaternion.identity);

            int spown_cloud = Random.Range(1,5);

            for(int c = 0; c <= spown_cloud; c++)
            {
                int Random_x = Random.Range(-8, 8);
                int Random_y = Random.Range(-20, -6);

                Instantiate(cloud[1], new Vector2(Random_x, Random_y), Quaternion.identity);
            }

        }
        else
        {
            i = 0;

            Spown_Rag++;

            if (Spown_Rag == 100)
            {
                Spown_flag = true;
                Spown_Rag = 0;
            }
        }

        if (time > 0)
        {
            time -= 0.01f; //経過時間を表示する値に反映する処理

        }
        else
        {
            if(goal_flag) time = 0;
        }

        if(time <= 4 && goal_flag == false) //ゴール地点に近づいた時
        {
            int rx = Random.Range(-6, 6);

            Vector2 pos = new Vector2(rx, -6);

            GameObject Grand =  Instantiate(goal[0], pos, Quaternion.identity); //地面を生成

            GameObject Point = Instantiate(goal[1], pos, Quaternion.identity); //着地地点を生成

            Point.name = "Goal_Point";

            Grand.name = "Grand";

            goal_flag = true;
        }

        if (goal_flag) Spown_flag = false;

        //ゲームオブジェクトScoreを取得して、残り時間を表示している

        GameObject score = GameObject.Find("Score");

        UnityEngine.UI.Text textComponent = score.GetComponent<UnityEngine.UI.Text>();

        textComponent.text = "地上まで残り\n"  + time + "秒";


        if(PlayerScript.Life == 0) //ゲームオーバーした時
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                goal_flag = false;
                GoalScript.return_chack = true;
                SceneManager.LoadScene("TaitolScene");
            }
        }

    }

}