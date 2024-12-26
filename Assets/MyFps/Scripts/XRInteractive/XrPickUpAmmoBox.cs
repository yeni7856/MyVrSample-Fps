using MyFps;
using UnityEngine;


namespace MyFps
{
    public class XrPickUpAmmoBox : SimpleInteractable
    {
        #region Variables
        //AmmoBox ������ ȹ��� �����ϴ� ammo ����
        [SerializeField] private int giveAmmo = 7;

        public AmmoUI ammoUI;
        #endregion

        protected override void DoAction()
        {
            //������ ����
            Debug.Log("źȯ 7���� ���� �߽��ϴ�");
            PlayerStats.Instance.AddAmmo(giveAmmo);
            ammoUI.ShowAmmoUI();

            //ų
            Destroy(gameObject);
        }
    }
}