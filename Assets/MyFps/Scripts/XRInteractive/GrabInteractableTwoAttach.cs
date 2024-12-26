using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{
    /// <summary>
    /// �ΰ��� Attach Point ����
    /// </summary>
    public class GrabInteractableTwoAttach : GrabInteractable
    {
        #region Variablse
        public Transform leftAttachTransform;
        public Transform rightAttachTransform;

        protected override void DoAction()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            //�ΰ��� Attach Point�� ��� �տ� ���� �����ؼ� ����
            if (args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTransform;
            }

            base.OnSelectEntering(args);
        }
        
        /*protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            //�ΰ��� Attach Point�� ��� �տ� ���� �����ؼ� ����
            if(args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTransform;
            }

            base.OnSelectEntered(args);
        }*/
    }
}