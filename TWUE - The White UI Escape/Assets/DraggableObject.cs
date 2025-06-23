using UnityEngine;

public class DraggableRigidbody : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isDragging = false;
    private Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDrag()
    {
        isDragging = true;
        if (isDragging)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPos = (Vector2)mouseWorldPos + (Vector2)offset;

            // 方向ベクトル（移動先方向）
            Vector2 direction = targetPos - rb.position;

            // 距離（移動量）
            float distance = direction.magnitude;

            // Raycastで壁との間に何かがあるか調べる
            RaycastHit2D hit = Physics2D.Raycast(rb.position, direction.normalized, distance, LayerMask.GetMask("Wall"));

            if (hit.collider != null)
            {
                // 壁にぶつかる場合は、手前で止める
                targetPos = hit.point - direction.normalized * 0.02f; // 2cm手前で止める
            }

            rb.MovePosition(targetPos);
        }
}


    void OnMouseUp()
    {
        isDragging = false;
    }
}
