using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

namespace MyFps
{
    public class AOpening : WorldMenuUI
    {
        #region Variables
        //public GameObject thePlayer;
        public SceneFader fader;
        public GameObject Locomotion;
        //public GameObject leftController;
        //public GameObject rightController;

        //sequence UI
    
        [SerializeField]
        private string sequence01 = "...Where am I?";
        [SerializeField]
        private string sequence02 = "I need get out of here";
        //음성 사운드
        public AudioSource line01;
        public AudioSource line02;
        #endregion

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            StartCoroutine(PlaySequence());
        }

        //오프닝 시퀀스
        IEnumerator PlaySequence()
        {
            //0.플레이 캐릭터 비 활성화
            //thePlayer.GetComponent<FirstPersonController>().enabled = false;
            Locomotion.SetActive(false);
            //ightController.SetActive(false);


            //1.페이드인 연출(4초 대기후 페인드인 효과)            
            fader.FromFade(4f + 2f); //5초동안 페이드 효과

            yield return new WaitForSeconds(2f);

            //2.화면 하단에 시나리오 텍스트 화면 출력(3초), 음성 출력
            //(...Where am I?)
            ShowMenuUI(sequence01);
            //textBox.text = sequence01;
            line01.Play();

            yield return new WaitForSeconds(3f);
            //(I need get out of here)
            //textBox.text = sequence02;
            ShowMenuUI(sequence02);
            line02.Play();

            //3. 3초후에 시나리오 텍스트 없어진다
            yield return new WaitForSeconds(3f);
            //textBox.text = "";
            HideMenuUI();

            //4.플레이 캐릭터 활성화
            //thePlayer.GetComponent<FirstPersonController>().enabled = true;
            Locomotion.SetActive(true);
            //rightController.SetActive(true);
        }

    }
}