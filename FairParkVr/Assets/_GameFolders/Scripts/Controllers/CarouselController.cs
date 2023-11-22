using UnityEngine;

namespace FairParkVr.Controllers
{
    public class CarouselController : MonoBehaviour
    {
        [SerializeField] float _rotationSpeed = 10f;
        [SerializeField] Transform _transform;

        void OnValidate()
        {
            if (_transform == null) _transform = GetComponent<Transform>();
        }

        void Update()
        {
            _transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);
        }
    }
}