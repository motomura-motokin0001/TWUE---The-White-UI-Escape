using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTweenの名前空間

public class Camerachange : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;      // メインカメラ
    [SerializeField] private float switchX = 5f;      // カメラの移動距離(X軸方向)
    [SerializeField] private float switchY = 5f;      // カメラの移動距離(Y軸方向)
    [SerializeField] private GameObject RightWall;    // 右の壁
    [SerializeField] private GameObject LeftWall;     // 左の壁
    [SerializeField] private GameObject _UpWall;       // 上の壁
    [SerializeField] private GameObject _DownWall;     // 下の壁
    [SerializeField] private GameObject _Player;      // プレイヤー

    private bool _isMoving = false; // カメラが移動中かどうかを判断するフラグ

    private bool _canMoveUp = true;
    private bool _canMoveDown = true;
    private bool _canMoveRight = true;
    private bool _canMoveLeft = true;

    void Update()
    {
        if (_isMoving) return;

        // 右
        if (_Player.transform.position.x >= RightWall.transform.position.x && _canMoveRight)
        {
            Debug.Log("右の壁に到達");
            MoveCamera_X(mainCamera.transform.position.x + switchX);
            _canMoveRight = false;
        }
        else if (_Player.transform.position.x < RightWall.transform.position.x)
        {
            _canMoveRight = true;
        }

        // 左
        if (_Player.transform.position.x < LeftWall.transform.position.x && _canMoveLeft)
        {
            Debug.Log("左の壁に到達");
            MoveCamera_X(mainCamera.transform.position.x - switchX);
            _canMoveLeft = false;
        }
        else if (_Player.transform.position.x >= LeftWall.transform.position.x)
        {
            _canMoveLeft = true;
        }

        // 上
        if (_Player.transform.position.y > _UpWall.transform.position.y && _canMoveUp)
        {
            Debug.Log("上の壁に到達");
            MoveCamera_Y(mainCamera.transform.position.y + switchY);
            _canMoveUp = false;
        }
        else if (_Player.transform.position.y <= _UpWall.transform.position.y)
        {
            _canMoveUp = true;
        }

        // 下
        if (_Player.transform.position.y < _DownWall.transform.position.y && _canMoveDown)
        {
            Debug.Log("下の壁に到達");
            MoveCamera_Y(mainCamera.transform.position.y - switchY);
            _canMoveDown = false;
        }
        else if (_Player.transform.position.y >= _DownWall.transform.position.y)
        {
            _canMoveDown = true;
        }
    }

    void MoveCamera_X(float targetX)
    {
        _isMoving = true;

        // カメラの目標位置
        Vector3 targetPos = new Vector3(targetX, mainCamera.transform.position.y, mainCamera.transform.position.z);// YとZは現在の位置を保持

        // DOTweenを使って0.5秒かけてカメラを移動
        mainCamera.transform.DOMove(targetPos, 0.5f).SetEase(Ease.InOutSine).OnComplete(() => _isMoving = false); // 移動が終わったらフラグ解除
    }
    void MoveCamera_Y(float targetY)
    {
        _isMoving = true;

        // カメラの目標位置
        Vector3 targetPos = new Vector3(mainCamera.transform.position.x, targetY, mainCamera.transform.position.z);// XとZは現在の位置を保持

        // DOTweenを使って0.5秒かけてカメラを移動
        mainCamera.transform.DOMove(targetPos, 0.5f).SetEase(Ease.InOutSine).OnComplete(() => _isMoving = false); // 移動が終わったらフラグ解除
    }
}
