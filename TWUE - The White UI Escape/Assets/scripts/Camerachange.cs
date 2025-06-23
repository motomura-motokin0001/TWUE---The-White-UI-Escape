using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camerachange : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;  // 左側のカメラ
    [SerializeField] private Camera subCamera;   // 右側のカメラ
    [SerializeField] private Image infoImage;//アドバイスメッセージの画像
    [SerializeField] private float switchX = 5f; // カメラを切り替えるX座標（適宜調整）
    [SerializeField] private float Display_Time = 3.0f;//アドバイスメッセージの表示時間
    [SerializeField] private GameObject _Player;//プレイヤーオブジェクト
    private bool AdviceMessage = true;//アドバイスメッセージを表示するかどうか
    private bool isMainCameraActive = true;

    void Update()
    {
        // プレイヤーのX座標を監視
        if (_Player.transform.position.x >= switchX && isMainCameraActive)
        {
            SwitchCamera(subCamera, mainCamera);
            isMainCameraActive = false;
            
        }
        else if (_Player.transform.position.x < switchX && !isMainCameraActive)
        {
            SwitchCamera(mainCamera, subCamera);
            isMainCameraActive = true;
        }
    }

    void SwitchCamera(Camera activate, Camera deactivate)
    {
        activate.enabled = true;
        deactivate.enabled = false;

            if(AdviceMessage == true)
            {
                AdviceMessage = false;
            }
    }
}


