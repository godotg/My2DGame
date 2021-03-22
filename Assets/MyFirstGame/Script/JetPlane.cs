using System;
using UnityEngine;

public class JetPlane : MonoBehaviour
{
    private float speed = 2.1F;

    public GameObject bullet;

    void Start()
    {
    }


    void Update()
    {
        Move();
        Fire();
    }


    private void Move()
    {
        var up = Input.GetKey(KeyCode.W);
        var down = Input.GetKey(KeyCode.S);
        var left = Input.GetKey(KeyCode.A);
        var right = Input.GetKey(KeyCode.D);

        var direction = Vector3.zero;
        if (up)
        {
            direction = direction + Vector3.up;
        }

        if (down)
        {
            direction = direction + Vector3.down;
        }

        if (left)
        {
            direction = direction + Vector3.left;
        }

        if (right)
        {
            direction = direction + Vector3.right;
        }

        if (direction != Vector3.zero)
        {
            var lastPosition = this.transform.position;
            this.transform.Translate(direction.normalized * speed * Time.deltaTime);

            // 检查是否超出屏幕范围
            var screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            if (screenPosition.x <= 0 || screenPosition.x >= Screen.width || screenPosition.y <= 0 || screenPosition.y >= Screen.height)
            {
                this.transform.position = lastPosition;
            }
        }
    }


    private void Fire()
    {
        var fire = Input.GetKeyDown(KeyCode.J);
        if (fire)
        {
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = this.transform.position + new Vector3(0F, 0.5F, 0F);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}