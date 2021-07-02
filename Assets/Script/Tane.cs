using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;			// Sliderを扱うために必要


public class Tane : MonoBehaviour
{
    float Gpoint = 0;//どれくらい成長したかを可視化した数字→成長度
    float MAX_Gpoint;//このスクリプトが付いているGpointの最大値
    public Slider Gslider;//成長ゲージ
    float onlineTime;
    
      private enum LOGIN_TYPE
    {
        FIRST_USER_LOGIN, //初回ログイン
        TODAY_LOGIN,      //ログイン
        ALREADY_LOGIN,    //ログイン済
        ERROR_LOGIN       //不正ログイン
    }

    private int todayDate = 0;
    private int lastDate;
    private int loginPoint;
    private LOGIN_TYPE judge_type;
    void Start()
    {
        MAX_Gpoint = Gslider.maxValue;//タネの最大値を取得

        //オフライン時間を取得して、Gpointに換算
        //CalculateOfflineEarnings();    // オフライン時の経過時間を計算//オフライン時間を取得
            //オフライン時間をGpointにいい感じに変換


        DateTime now = DateTime.Now;//端末の現在時刻の取得        
        if(now.Month == 1|now.Month == 3|now.Month == 5|now.Month == 7|now.Month == 8|now.Month == 10|now.Month == 12)
        {
            todayDate = now.Year*12*31*24*60 + now.Month*31*24*60 + now.Day*24*60 + now.Hour*60 + now.Minute;//日付を何分に変換
        } 
         else if(now.Month == 4|now.Month == 6|now.Month == 9|now.Month == 11)
        {
            todayDate = now.Year*12*30*24*60 + now.Month*30*24*60 + now.Day*24*60 + now.Hour*60 + now.Minute;
        }
        else
        {
            todayDate = now.Year*12*29*24*60 + now.Month*29*24*60 + now.Day*24*60 + now.Hour*60 + now.Minute;       
        }

        //前回ログイン時の日付データをロード データがない場合はFIRST_USER_LOGINで0
        lastDate = PlayerPrefs.GetInt("LastGetDate", (int)LOGIN_TYPE.FIRST_USER_LOGIN);


        //前回と今回の日付データ比較
        
        if (lastDate < todayDate)//日付が進んでいる場合
        {
            judge_type = LOGIN_TYPE.TODAY_LOGIN;
        }        
        else if (lastDate == todayDate)//日付が進んでいない場合
        {
            judge_type = LOGIN_TYPE.ALREADY_LOGIN;
        }
        else if (lastDate > todayDate)//日付が逆転している場合
        {
            judge_type = LOGIN_TYPE.ERROR_LOGIN;
        }


        switch (judge_type)
        {
            //ログインボーナス
            case LOGIN_TYPE.TODAY_LOGIN:

                //初ログインボーナス　lastDateに0が入っていたら処理実行
                if (lastDate == (int)LOGIN_TYPE.FIRST_USER_LOGIN)
                {
                    //初ログインボーナス処理
                    Debug.Log("初回ログイン");
                }
                else
                {
                    //普通のログインボーナス処理
                    loginPoint = todayDate - lastDate;
                    Debug.Log("経過時間"+ loginPoint);
                    AddGrowPoint(loginPoint);
                }               

                break;

            //すでにログイン済み
            case LOGIN_TYPE.ALREADY_LOGIN:
                //なにもしない
                break;

            //不正ログイン
            case LOGIN_TYPE.ERROR_LOGIN:
                //不正ログイン時の処理
                break;
        }
        //今回取得した日付をセーブ
        PlayerPrefs.SetInt("LastGetDate", todayDate);
        PlayerPrefs.Save();
    }

    void Update()
    {
        onlineTime += Time.deltaTime;//時間取得

        if(onlineTime > 3)//○○秒ごとに
        {
            AddGrowPoint(50.0f);//Gpointを○○取得
            onlineTime = 0; //時間を0にする
        }
        //Debug.Log("成長度"+Gpoint);
        //Debug.Log("取得時間"+onlineTime);
    }
    public void AddGrowPoint(float val)
    {
        Gpoint += val;
        Gslider.value = Gpoint;
        if(Gpoint > MAX_Gpoint)
        {
            //ゾンビ生成
            Destroy(this.gameObject); //タネが消える
                //ゾンビナンバー取得（メインシーンでゾンビを生成する数字）
                    //数値取得
                    //数値保存         
        }
    }
    // public void CalculateOfflineEarnings()
    // {
    //     DateTime currentDateTime = DateTime.Now;
    //     if (oldDateTime > currentDateTime) {
    //         //データ不正：セーブデータの時間の方が今の時間よりも進んでいたので今の時間を入れる
    //         oldDateTime = DateTime.Now;
    //     }
        
    //     //アプリを停止→再開していた経過時間計算
    //     TimeSpan timeElasped = currentDateTime - oldDateTime;    //経過した時間
    //     float elapsedTimeInSeconds = (int)Math.Round(timeElasped.TotalSeconds, 0, MidpointRounding.ToEven); //経過時間を
    //     Debug.Log($"オフラインでの経過時間:{elapsedTimeInSeconds}秒");
    // }
}
