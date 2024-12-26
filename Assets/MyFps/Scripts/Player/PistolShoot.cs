using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

namespace MyFps
{
    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        //private Animator animator;
        //
        public ParticleSystem muzzle;
        public AudioSource pistolShot;

        //public Transform camera;
        public Transform firePoint;

        //공격력
        //[SerializeField] private float attackDamage = 5f;

        //연사 딜레이
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;

        public GameObject bulletPrefab;
        public float bulletSpeed = 50f;

        public AmmoUI ammoUI;

        //임팩트
        //public GameObject hitImpactPrefab;
        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.activated.AddListener(Fire);
        }

        void Fire(ActivateEventArgs args)
        {
            if (isFire == false && PlayerStats.Instance.UseAmmo(1) == true)
            {
                StartCoroutine(Shoot());
            }
        }

        IEnumerator Shoot()
        {
            isFire = true;

            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletGo.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
            Destroy(bulletGo, 5f);

            //내앞에 100안에 적이 있으면 적에게 데미지를 준다
    /*    float maxDistance = 100f;
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                //적에게 데미지를 준다
                //Debug.Log($"{hit.transform.name}에게 데미지를 준다");
                //hit 이펙트
                GameObject eff = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(eff, 2f);

                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(attackDamage);
                }
             }*/

            //슛 효과 - VFX, SFX
            //animator.SetTrigger("Fire");
            pistolShot.Play();

            muzzle.gameObject.SetActive(true);
            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);


            //UI
            ammoUI.ShowAmmoUI();
            isFire = false;
        }


        //Gimo 그리기 : 총 위치에서 앞에 충돌체까지 레이저 쏘는 선 그리기
        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            if (isHit)
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * maxDistance);
            }
        }
    }
}  