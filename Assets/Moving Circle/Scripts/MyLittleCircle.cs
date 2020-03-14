using UnityEngine;

namespace MovingCirle
{
    public class MyLittleCircle : MonoBehaviour
    {
        public float MoveSpeed { get; set; }

        public Vector3 GetPosition { get => transform.position; }

        public void MoveToTarget(Vector3 targetPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, MoveSpeed * Time.deltaTime);
        }
    }
}
