using UnityEngine;

public class MySample : MonoBehaviour
{
    private void Test()
    {
        // 设置父子关系，unity这种父子关系都是通过transform组件完成
        var parent = this.transform.parent.gameObject;
        foreach (Transform child in transform)
        {
            Debug.Log("子节点: " + child.name);
        }


        var obj = GameObject.Find("小飞机");
        var target = GameObject.Find("物体");

        // 将obj的父物体设置为target
        obj.transform.SetParent(target.transform);

        // 挂在场景根节点下面
        obj.transform.SetParent(null);


        // 坐标与旋转
        this.transform.position = new Vector3(1.5f, 1.5F, 0);
        this.transform.eulerAngles = new Vector3(0, 0, 45F);


        // 物体的运动，自身的坐标系，世界的坐标系
        this.transform.Translate(0, 1F, 0, Space.Self);
        this.transform.Translate(0, 1F, 0, Space.World);


        // 向量指具有大小（magnitude）和方向的量
        var vec = new Vector3(1.0F, 1.0F, 1.0F);
        // len = sqrt(x * x + y * y);
        var len = vec.magnitude;
        // 单位向量，标准化向量，长度为1的向量
        var normalLen = vec.normalized;
        Debug.Log(normalLen.ToString("F3"));
        // 向量的加法，各分量相加
        Debug.Log(Vector3.right + Vector3.up);
        // 向量的减法，各分量相减，可以用来求两点间的距离
        // 向量的乘法，分为3钟：
        // 1.标量乘法，a = b * 2
        // 2.点积(数量积)，c = Vector3.Dot(a, b)，几何定义：a * b = |a||b|cos@，代数定义：a * b = (x1 * x2 + y1 * y2)
        // 3.叉积，c = Vector3.Cross(a, b)


        // 世界坐标和屏幕坐标
        var worldPosition = Vector3.right;
        // 屏幕坐标返回的是，相对于屏幕左下角的像素坐标
        var screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
    }


    void Start()
    {
        var source = GameObject.Find("飞机");
        var target = GameObject.Find("角色");

        var face = source.transform.up;
        var direction = target.transform.position - source.transform.position;
        var angle = Vector3.SignedAngle(face, direction, Vector3.forward);

        source.transform.Rotate(Vector3.forward, angle);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0F, 1.2F * Time.deltaTime, 0F, Space.Self);
    }
}