using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // 動かすオブジェクト
    [SerializeField] private Vector3 speed; //初期速度
    [SerializeField] private Vector2 StartPosition; // スタート位置
    [SerializeField] private Vector2 EndPosition; //  エンド位置
    [SerializeField] private bool _P, _M;
    private Vector2 TOobj; // ターゲットオブジェクトの位置
    private bool _Down = false;
    private bool _Up = false;

    void Start()
    {
        targetObject.position = StartPosition;
        TOobj = targetObject.transform.position;
    }

    void Update()
    {
        if (_Down) Down();
        if (_Up) Up();
    }

    public void OnPointerDown()
    {
        _Down = true;
        _Up = false;
    }

    public void OnPointerUp()
    {
        _Up = true;
        _Down = false;
    }

    private void Down()
    {
        Debug.Log("OnPointerDown");
        if (_P)
        {
            TOobj.y += 1;
        }
        else if (_M)
        {
            TOobj.y -= 1;
        }
    }

    private void Up()
    {
        Debug.Log("OnPointerUp");
        if (_P)
        {
            TOobj.y -= 1;
        }
        else if (_M)
        {
            TOobj.y += 1;
        }
    }
}
