using System.Collections;
using UnityEngine;

namespace MyFps
{
    public class AmmoUI : WorldMenuUI
    {
        #region Variables
        [SerializeField] private float showDelay = 2f;
        #endregion

        public void ShowAmmoUI()
        {
            StartCoroutine(ShowUI());
        }

        IEnumerator ShowUI()
        {
            ShowMenuUI(PlayerStats.Instance.AmmoCount.ToString());

            yield return new WaitForSeconds(showDelay);
            
            HideMenuUI();
        }

    }
}