using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVrSample
{
    /// <summary>
    /// ��Ʈ�ѷ� �� �� �ִϸ��̼� ����
    /// </summary>
    public class AnimateHandOnInput : MonoBehaviour
    {
        #region Variables
        private Animator handAnimator;

        //��ǲ �Է°� ó��
        public InputActionProperty pinchAnimationAction;
        public InputActionProperty gripAnimationAction;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //����
            handAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            float triggerValue = pinchAnimationAction.action.ReadValue<float>();
            float gripValue = gripAnimationAction.action.ReadValue<float>();
            //Debug.Log($"triggerValue: {triggerValue}");

            handAnimator.SetFloat("Trigger", triggerValue);
            handAnimator.SetFloat("Grip", gripValue);
        }
    }
}