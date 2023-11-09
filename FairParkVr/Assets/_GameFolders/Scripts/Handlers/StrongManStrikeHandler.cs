using Cysharp.Threading.Tasks;
using FairParkVr.Controllers;
using FairParkVr.Services;
using UnityEngine;

namespace FairParkVr.Handlers
{
    public class StrongManStrikeHandler : MonoBehaviour
    {
        [SerializeField] float _multiplier = 0.01f;
        
        StrongManService _strongManService;

        async void Start()
        {
            while (_strongManService == null)
            {
                _strongManService = FindObjectOfType<StrongManService>();
                await UniTask.Yield();
            }
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag("Hammer"))
            {
                if (other.transform.TryGetComponent(out HammerController hammerController))
                {
                    _strongManService.Strike(hammerController.Rigidbody.mass, other.relativeVelocity.magnitude, _multiplier);
                }
            }
        }
    }
}