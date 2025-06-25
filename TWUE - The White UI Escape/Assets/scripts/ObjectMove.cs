using UnityEngine;
using DG.Tweening;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // 動かすオブジェクト
    [SerializeField] private Vector3 StartPosition; // スタート位置
    [SerializeField] private Vector3 EndPosition; //  エンド位置

    public void OnPointerDown()
    {
        Debug.Log("OnPointerDown");
        targetObject.DOMove(EndPosition, 1f).SetEase(Ease.InOutQuad);
    }

    public void OnPointerUp()
    {
        Debug.Log("OnPointerUp");
        targetObject.DOMove(StartPosition, 1f).SetEase(Ease.InOutQuad);
    }
}
