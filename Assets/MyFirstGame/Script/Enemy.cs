using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static readonly float TOTAL_HP = 10F;

    private float speed = 2.1F;

    private float hp = TOTAL_HP;

    private Transform hpNode;

    private void Start()
    {
        hpNode = this.transform.Find("hpbar/hpvalue");
    }

    void Update()
    {
        var position = this.transform.position;
        if (position.y < -5)
        {
            Destroy(this.gameObject);
        }

        // 让敌人向下移动
        this.transform.Translate(0F, -speed * Time.deltaTime, 0F);
    }

    public void OnFired()
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }


        hpNode.localScale = new Vector3(hp / TOTAL_HP, 1F, 1F);
    }
}