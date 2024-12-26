using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace MyVrSample
{
    /// <summary>
    /// Teleport Ray�� �����ϴ� Ŭ����
    /// </summary>
    public class ActivateTeleportRay : MonoBehaviour
    {
        #region Variables
        public GameObject leftTeleportRay;          //�ڷ���Ʈ ���� Ray ������Ʈ
        public GameObject rightTeleportRay;         //�ڷ���Ʈ ������ Ray ������Ʈ

        public InputActionProperty leftActivate;    //���� ��Ʈ�ѷ��� Activate �Է�
        public InputActionProperty rightActivate;   //������ ��Ʈ�ѷ��� Activate �Է�

        public XRRayInteractor leftGrapLay;
        public XRRayInteractor rightGrapLay;
        #endregion

        private void Update()
        {
            float leftActivateValue = leftActivate.action.ReadValue<float>();
            float rightActivateValue = rightActivate.action.ReadValue<float>();

            bool isLeftRayHovering = leftGrapLay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal,
                out int leftNumber, out bool leftValid);
            bool isRightRayHovering = rightGrapLay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal,
                out int rightNumber, out bool rightValid);

            leftTeleportRay.SetActive(!isLeftRayHovering && leftActivateValue > 0.1f);
            rightTeleportRay.SetActive(!isRightRayHovering && rightActivateValue > 0.1f);
        }
    }
}