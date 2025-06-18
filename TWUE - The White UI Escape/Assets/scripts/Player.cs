using UnityEngine;
using UnityEngine.InputSystem;

//このスクリプトではプレイヤーの基本的な動作を制御しています。
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _PlayerInput;
    private Rigidbody2D _rb;
    private bool isGrounded = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MOVE();
        Jump();

        void MOVE()
        {
            Vector2 moveInput = _PlayerInput.actions["Move"].ReadValue<Vector2>();
            if (moveInput != Vector2.zero)
            {
                // プレイヤーの移動処理
                Vector2 moveDirection = moveInput.normalized * 5f; // 速度を5に設定
                _rb.velocity = new Vector2(moveDirection.x, _rb.velocity.y); // 水平方向の速度のみ変更
                Debug.Log($"Moving: {moveDirection}");
            }
            else
            {
                // 入力がない場合は速度を0にする
                _rb.velocity = new Vector2(0, _rb.velocity.y);
                Debug.Log("Not moving");
            }
        }
    }

    void Jump()
    {
        if (_PlayerInput.actions["Jump"].triggered && isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 5f); // ジャンプの速度を5に設定
            Debug.Log("Jump triggered");
        }
    }




void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log($"名前: {collision.gameObject.name}");
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }
}

void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = false;
    }
}
}


