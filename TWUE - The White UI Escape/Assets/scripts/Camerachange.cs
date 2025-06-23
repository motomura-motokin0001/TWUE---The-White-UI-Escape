using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTweenの名前空間

public class Camerachange : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;      // メインカメラ
    [SerializeField] private float switchX = 5f;      // カメラの移動距離
    [SerializeField] private GameObject RightWall;    // 右の壁
    [SerializeField] private GameObject LeftWall;     // 左の壁
    [SerializeField] private GameObject _Player;      // プレイヤー

    private bool _isMoving = false; // カメラが移動中かどうかを判断するフラグ

    void Update()
    {
        if (_isMoving) return;

        // プレイヤーが右の壁より右に移動したら
        if (_Player.transform.position.x >= RightWall.transform.position.x)
        {
            Debug.Log("右の壁に到達");
            MoveCamera(mainCamera.transform.position.x + switchX);
        }
        // プレイヤーが左の壁より左に移動したら
        else if (_Player.transform.position.x < LeftWall.transform.position.x)
        {
            Debug.Log("左の壁に到達");
            MoveCamera(mainCamera.transform.position.x - switchX);
        }
    }

    void MoveCamera(float targetX)
    {
        _isMoving = true;

        // カメラの目標位置
        Vector3 targetPos = new Vector3(targetX, mainCamera.transform.position.y, mainCamera.transform.position.z);

        // DOTweenを使って0.5秒かけてカメラを移動
        mainCamera.transform.DOMove(targetPos, 0.5f).SetEase(Ease.InOutSine).OnComplete(() => _isMoving = false); // 移動が終わったらフラグ解除
    }
}
