//星の仕様
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Transformクラスの「Rotate」関数は、現在の角度から引数に与えた角度のぶんだけ回転する関数
//引数には、第一引数から順番に、X軸、Y軸、Z軸を中心とした回転量を渡す

public class StarController : MonoBehaviour
{
    // 回転速度
    private float rotSpeed = 0.5f;

    // Use this for initialization
    void Start()
    {
        //回転を開始する角度を設定
        //Start関数で回転を開始する角度をランダムに決めることで、
        //星が複数ある場合はすべての星がバラバラに回転しているように見せる
        //Randomクラスの「Range」関数は、第一引数以上、第二引数未満の整数をランダムに返す
        this.transform.Rotate(0, Random.Range(0, 360), 0);
    }

    void Update()
    {
        //回転
        //Y軸を中心として星を回転させたいので、第2引数にrotSpeedの値を指定している
        this.transform.Rotate(0, this.rotSpeed, 0);
    }
}
