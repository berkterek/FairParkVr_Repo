using UnityEngine;

namespace FairParkVr.Controllers
{
    public class HammerController : MonoBehaviour
    {
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] Transform _centerOffMass;

        public Rigidbody Rigidbody => _rigidbody;

        void OnValidate()
        {
            if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            _rigidbody.centerOfMass = _centerOffMass.localPosition;
        }
    }    
}

