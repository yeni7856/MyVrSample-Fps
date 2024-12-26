using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace MyFps
{

    public class XrDoorCellOpen : SimpleInteractable
    {
        #region Variables
        //action
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;
        #endregion

        protected override void Start()
        {
            base.Start();

            animator = GetComponent<Animator>();
            m_Collider = GetComponent<BoxCollider>();
        }

        protected override void DoAction()
        {
            animator.SetBool("IsOpen", true);
            m_Collider.enabled = false;
            audioSource.Play();
        }

    }
}