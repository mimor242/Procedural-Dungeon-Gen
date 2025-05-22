using System.Diagnostics;
using UnityEngine;

public class WallCollision : MonoBehaviour
{

    public Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f); // 벽 크기에 맞게 조정

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider[] hits = Physics.OverlapBox(transform.position, halfExtents * 0.95f, Quaternion.identity);
        foreach (Collider hit in hits)
        {
            if (hit == GetComponent<Collider>()) continue;

            // '실제 충돌 판단할 벽'은 Box Collider가 존재함
            if (hit is BoxCollider && hit.gameObject != gameObject)
            {
                UnityEngine.Debug.Log($"Destroyed {gameObject.name} due to overlap with {hit.name}");
                Destroy(gameObject);
                return;
            }
        }
    }
}
