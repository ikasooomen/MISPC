using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // 体力値を格納する変数（定数値 100）
    public const int maxHealth = 100;
    // 現在の体力値を格納する変数（初期値は maxHealth）
    public int currentHealth = maxHealth;

    // ダメージ処理
    public void TakeDamage(int amount)
    {
        // 現在の体力値から 引数 amount の値を引く
        currentHealth -= amount;
        // 現在の体力値が 0 以下の場合
        if (currentHealth <= 0)
        {
            // 現在の体力値に 0 を代入
            currentHealth = 0;
            // コンソールに"Dead!"を表示する
            Debug.Log("Dead!");
        }
    }
}