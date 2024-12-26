using UnityEngine;

namespace MyFps
{
    public class Bullet : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float attackDamage = 5f;
        //임팩트
        public GameObject hitImpactPrefab;
        #endregion

        //충돌체크
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"collision: {collision.gameObject.name}");

            GameObject effGO = Instantiate(hitImpactPrefab, transform.position, 
                Quaternion.LookRotation(transform.forward * -1));           //-1 곱해서 반대방향
            Destroy(effGO, 2f);

            IDamageable damageable = collision.transform.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }

           Destroy(gameObject);
        }
    }
}