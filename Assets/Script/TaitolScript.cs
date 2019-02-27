using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaitolScript : MonoBehaviour {

    public GameObject Screen;

    int Type;

    void Start()
    {
        Type = 0;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (Type)
            {
                case 0:

                    Screen.transform.position = new Vector2(-18, 0);

                    Type++;

                    break;

                case 1:

                    BackgroundScript.scrolcnt = 50;

                    SceneManager.LoadScene("GameScene");

                    Type = 0;

                    break;
            }

        }

    }
}
