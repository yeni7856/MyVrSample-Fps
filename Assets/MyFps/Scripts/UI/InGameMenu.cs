using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;


namespace MyFps
{
    public class InGameMenu : MonoBehaviour
    {
        #region Variables
        public GameObject gameMenu;
        public InputActionProperty showButton;

        private Transform head;
        [SerializeField] private float distance = 1.5f;
        #endregion

        private void Start()
        {
            head = Camera.main.transform;
        }

        private void Update()
        {
            distance = PlayerCasting.distanceFromTarget;

            if (showButton.action.WasPressedThisFrame())
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            gameMenu.SetActive(!gameMenu.activeSelf);

            //show ����
            if (gameMenu.activeSelf)
            {
                distance = (distance < 1.5f) ? distance - 0.05f : 1.5f; //distance������ �Ÿ��� 1.5���ϸ� 0.1���� ��ũ�� 1.5f

                gameMenu.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * distance;
                gameMenu.transform.LookAt(new Vector3(head.position.x, gameMenu.transform.position.y, head.position.z));
                gameMenu.transform.forward *= -1;
            }
        }

         //Quit ��ư
        public void Quit()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}