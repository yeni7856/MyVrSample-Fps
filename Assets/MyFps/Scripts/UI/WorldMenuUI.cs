using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


namespace MyFps
{
    public class WorldMenuUI : MonoBehaviour
    {
        public GameObject worldMenuUI;
        public TextMeshProUGUI textbox;
        private Transform head;
        private float distance;
        [SerializeField] private float offset = 1.0f;

        protected virtual void Start()
        {
            head = Camera.main.transform;
        }
        protected virtual void Update()
        {
            distance = PlayerCasting.distanceFromTarget;
        }

        protected void ShowMenuUI(string sequenceText = "")
        {
            worldMenuUI.SetActive(true);

            //show ����
            distance = (distance < offset) ? distance - 0.05f : offset; //distance������ �Ÿ��� 1.5���ϸ� 0.1���� ��ũ�� 1.5f

            worldMenuUI.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * distance;
            worldMenuUI.transform.LookAt(new Vector3(head.position.x, worldMenuUI.transform.position.y, head.position.z));
            worldMenuUI.transform.forward *= -1;

            //text ����
            if (textbox)
            {
                textbox.text = sequenceText;    
            }
        }

        protected void HideMenuUI()
        {
            worldMenuUI.SetActive(false);
            textbox.text = "";
        }
    }

}