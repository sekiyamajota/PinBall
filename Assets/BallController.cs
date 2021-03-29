using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //得点を表示するテキスト
    private GameObject pointText;

    //合計点
    int sum = 0;

    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        //GameObjectクラスの「Find」関数は、引数に与えた文字列の名前のオブジェクトをシーン中から取得する
        this.gameoverText = GameObject.Find("GameOverText");
        this.pointText = GameObject.Find("PointText");
        this.pointText.GetComponent<Text>().text = sum + "ポイント";
    }

    
    void Update()
    {
        //ボールが画面外に出た場合
        //Transformクラスの「position」は、オブジェクトの座標の値が入っている
        //x, y, z座標すべてに一度にアクセスしたい場合は「position」、x座標にアクセスしたい場合は「position.x」、
        //y座標にアクセスしたい場合は「position.y」、z座標にアクセスしたい場合は「position.z」とする
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            //Textクラスの「text」は、Textコンポーネントに表示する文字列を指定できる
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            //得点を非表示
            this.pointText.GetComponent<Text>().text = "";
        }
    }

    //OnCollisionEnter! 追加
    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject!
        if (collision.gameObject.tag == "SmallStarTag")
        {
            sum += 1;
            this.pointText.GetComponent<Text>().text = sum+"ポイント";
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            sum += 5;
            this.pointText.GetComponent<Text>().text = sum + "ポイント";
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            sum += 20;
            this.pointText.GetComponent<Text>().text = sum + "ポイント";
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            sum += 50;
            this.pointText.GetComponent<Text>().text = sum+"ポイント";
        }
    }
}
