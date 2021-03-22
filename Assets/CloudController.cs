//雲の仕様
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Vectorはオブジェクトの座標やオブジェクトに加わる力の方向などを扱う型
Vector2はfloat型のx, yの要素を持っており、Vector3はfloat型のx, y, zの要素を持っている
また、Vectorはインスタンスを生成して使う。たとえば、Vector3の変数を宣言して使うときは、
Vector3 vec = new Vector3(1.0f, 2.0f, 3.0f);」などのように使う
第一引数にX軸方向、第二引数にY軸方向、第三引数にZ軸方向の値を設定する
*/
public class CloudController : MonoBehaviour
{
    //最小サイズ
    private float minimum = 1.0f;
    //拡大縮小スピード
    private float magSpeed = 10.0f;
    //拡大率
    private float magnification = 0.07f;

    void Start()
    {

    }

    //Mathfクラスの「Sin」関数は、引数に与えた角度をサインの値で返す。また、引数はラジアンで指定
    //Timeクラスの「time」は、ゲーム開始から何秒経ったかを取得
    void Update()
    {
        //雲を拡大縮小
        //オブジェクトのサイズを変更するためには、「transform.localScale」にそれぞれの軸方向の拡大率を指定
        //また、localScaleに値を代入するときは、Vector3を用いる
        this.transform.localScale = new Vector3(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);

    }
}
