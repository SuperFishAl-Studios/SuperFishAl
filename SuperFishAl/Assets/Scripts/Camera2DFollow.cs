using System.Linq;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 10;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
            var childTransform = target.GetComponentsInChildren<Transform>().Last();
            m_LastTargetPosition = childTransform.position;
            m_OffsetZ = (transform.position - childTransform.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            var childTransform = target.GetComponentsInChildren<Transform>().Last();
            // only update lookahead pos if accelerating or changed direction
            float yMoveDelta = (childTransform.position - m_LastTargetPosition).y;

            bool updateLookAheadTarget = Mathf.Abs(yMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor * Vector3.up * Mathf.Sign(yMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = childTransform.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = childTransform.position;
        }
    }
}
