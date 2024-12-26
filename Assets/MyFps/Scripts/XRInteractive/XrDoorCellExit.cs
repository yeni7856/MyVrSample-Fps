using System.Collections;
using UnityEngine;

namespace MyFps
{
    public class XrDoorCellExit : SimpleInteractable
    {
        #region Variables
        public SceneFader fader;
        //[SerializeField] private string loadToScene = "MainScene02";

        private Animator animator;
        private Collider m_Collider;
        public AudioSource creakyDoor; //������ �Ҹ�

        public AudioSource bgm01;         //�����
        #endregion

        protected override void Start()
        {
            base.Start();

            //����
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<Collider>();
        }

        protected override void DoAction()
        {
            //1.������ �ִϸ��̼�
            //2.������ ����
            animator.SetBool("IsOpen", true);
            m_Collider.enabled = false;

            creakyDoor.Play();

            StartCoroutine(ChangeScene());
        }

        IEnumerator ChangeScene()
        {
            //��������, .... bmg stop
            bgm01.Stop();

            //���������� �̵�
            fader.FadeTo(-1);

            yield return new WaitForSeconds(2f);
            
            //��������
            Application.Quit();
        }
    }
}
