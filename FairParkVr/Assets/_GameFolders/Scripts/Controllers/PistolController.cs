using System;
using Cysharp.Threading.Tasks;
using FairParkVr.Services;
using UnityEngine;

namespace FairParkVr.Controllers
{
    public class PistolController : MonoBehaviour
    {
        [SerializeField] float _fireDistance = 100f;
        [SerializeField] Transform _firePoint;

        DartBoothService _dartBoothService;

        async void Start()
        {
            while (_dartBoothService == null)
            {
                _dartBoothService = FindObjectOfType<DartBoothService>();
                await UniTask.Yield();
            }
        }

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
                    _dartBoothService.PopBalloon();
                }
            }
        }
    }    
}