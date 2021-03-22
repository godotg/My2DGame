using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject bg1;
    public GameObject bg2;

    private float speed = 2.5F;

    // Update is called once per frame
    void Update()
    {
        bg1.transform.Translate(0F, -speed * Time.deltaTime, 0F);
        bg2.transform.Translate(0F, -speed * Time.deltaTime, 0F);

        var position1 = bg1.transform.position;
        if (position1.y < -10F)
        {
            bg1.transform.position = new Vector3(0, 10F, 0);
            bg2.transform.position = Vector3.zero;
        }

        var position2 = bg2.transform.position;
        if (position2.y < -10F)
        {
            bg2.transform.position = new Vector3(0, 10F, 0);
            bg1.transform.position = Vector3.zero;
        }
    }
}