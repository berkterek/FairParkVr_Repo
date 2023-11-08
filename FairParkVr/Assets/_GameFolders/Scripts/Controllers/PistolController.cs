using UnityEngine;

namespace FairParkVr.Controllers
{
    public class PistolController : MonoBehaviour
    {
        [SerializeField] float _fireDistance = 100f;
        [SerializeField] Transform _firePoint;

        public void Fire()
        {
            Debug.Log("Fire triggered");
            if (Physics.Raycast(_firePoint.position, _firePoint.forward, out RaycastHit hit, _fireDistance))
            {
                Debug.Log("Fire inside raycast triggered");
                if (hit.transform.CompareTag("Balloon"))
                {
                    Debug.Log("Fire inside raycast if balloon tag triggered");
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
    }    
}