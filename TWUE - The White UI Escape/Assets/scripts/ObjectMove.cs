using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // 動かすオブジェクト
    [SerializeField] private Vector2 StartPosition; // スタート位置
    [SerializeField] private Vector2 EndPosition; //  エンド位置

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
