using UnityEngine;

namespace FairParkVr.Handlers
{
    [RequireComponent(typeof(AudioSource))]
    public class CollisionSoundHandler : MonoBehaviour
    {
        [SerializeField] string _objectTag;
        [SerializeField] AudioSource _audioSource;
        [SerializeField] float _minPitch = 0.9f;
        [SerializeField] float _maxPitch = 1.1f;

        void OnValidate()
        {
            if (_audioSource == null) _audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag(_objectTag)) return;

            _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}