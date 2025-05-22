using UnityEngine;

public class DiagonalCollision : MonoBehaviour
{
    public Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f); // 벽 크기에 맞게 조정
    public string targetTag = "Pillar"; // 삭제할 대상의 태그

    void Start()
    {
        Collider[] hits = Physics.OverlapBox(transform.position, halfExtents * 0.95f, Quaternion.identity);

        foreach (Collider hit in hits)
        {
            if (hit == GetComponent<Collider>()) continue;

            // 조건: BoxCollider + 태그 일치
            if (hit is BoxCollider && hit.CompareTag(targetTag))
            {
                UnityEngine.Debug.Log($"Destroyed {gameObject.name} due to overlap with tagged object: {hit.name}");
                Destroy(gameObject);
                return;
            }
        }
    }
}
