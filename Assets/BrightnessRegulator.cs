//物質を光らせる仕様
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    // Materialを入れる(GetComponentする為)
    Material myMaterial;

    // Emission(光の色と強さ)の最小値
    private float minEmission = 0.3f;
    // Emissionの強度
    private float magEmission = 2.0f;
    // 角度
    private int degree = 0;
    //発光速度
    private int speed = 10;
    // ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    //初期設定
    void Start()
    {

        // タグによって光らせる色を変える
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }
        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
        }

        //オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        //Materialクラスの「SetColor」関数は、マテリアルの色を設定、
        //第一引数に変更したい色のパラメータを指定し、第二引数に変更する色の値を設定する
        //ここでは発光する色の強さを変更したいので、第一引数にEmissionのパラメータ名である_EmissionColorを指定し、
        //第二引数にはTagで個々に設定した色を最小限に光らせた値を指定している
        //なぜthisを付けないのか
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);　//関数発動
    }

    void Update()
    {

        if (this.degree >= 0)
        {
            // 光らせる強度を計算する
            //if文の中で以下のようにSin関数を使うことで、光の強さを弱→強→弱と滑らかに変化するよう、計算している
            //「Color」は色を設定するためのクラス。ここでは、色の種類に発光の強さを掛けて代入している
            //また、Sin関数に渡す値は度数ではなくラジアンでなくてはならないため、
            //this.degree * Mathf.Deg2Rad?と記述して度数をラジアンに変換している
            //Mathf.Deg2Radは、度数に掛けることでラジアンに変換できる
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            // エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            //毎フレーム、計算したemissionColorの値をSetColorに渡すことで滑らかに光の強さを変化しています。
            //if文の最後でspeed変数の分だけdegree変数の値を減らし、degree変数の値が負になるまで毎フレームif文を実行する
            //for文の様な繰り返し処理をしている
            this.degree -= this.speed;
        }
    }

    //衝突時に呼ばれる関数(イベント関数)
    //引数には接触した相手のCollisionが渡される
    //「Collision」は、衝突したオブジェクトの情報が取得できるクラス
    void OnCollisionEnter(Collision other)
    {
        //Sin関数で使う為の角度を180に設定
        this.degree = 180;
    }
}