using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 4.1F;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > 5F)
        {
            Destroy(this.gameObject);
            return;
        }

        this.transform.Translate(0F, speed * Time.deltaTime, 0F);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherTag = other.gameObject.tag;
        if (otherTag.Equals("Enemy"))
        {
            Destroy(this.gameObject);
            other.GetComponent<Enemy>().OnFired();
        }
    }
}