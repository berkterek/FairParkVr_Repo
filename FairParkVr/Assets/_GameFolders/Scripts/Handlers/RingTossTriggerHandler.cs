using System.Threading;
using Cysharp.Threading.Tasks;
using FairParkVr.Services;
using UnityEngine;

namespace FairParkVr.Handlers
{
    public class RingTossTriggerHandler : MonoBehaviour
    {
        [SerializeField] float _waitSeconds = 3f;

        bool _isAroundBottle;
        RingTossBoothService _ringTossBoothService;
        CancellationTokenSource _cancellationTokenSource;
        CancellationToken _cancellationToken;

        async void Start()
        {
            while (_ringTossBoothService == null)
            {
                _ringTossBoothService = FindObjectOfType<RingTossBoothService>();
                await UniTask.Yield();
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bottle"))
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationTokenSource.Cancel();
                }

                _isAroundBottle = true;
                ScoreDelayAsync();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Bottle"))
            {
                _isAroundBottle = false;
            }
        }

        async void ScoreDelayAsync()
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(_waitSeconds), DelayType.DeltaTime, PlayerLoopTiming.Update,
                _cancellationToken);

            if (_ringTossBoothService != null && _isAroundBottle)
            {
                _ringTossBoothService.AddScore();
            }
        }
    }
}