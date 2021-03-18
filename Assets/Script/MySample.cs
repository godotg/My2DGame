using UnityEngine;

public class MySample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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
    }

    // Update is called once per frame
    void Update()
    {
    }
}