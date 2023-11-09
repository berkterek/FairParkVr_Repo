using FairParkVr.Services;
using UnityEngine;

namespace FairParkVr.Managers
{
    public class PrizeManager : MonoBehaviour
    {
        [SerializeField] int _ringTossPrizeScore = 0;
        [SerializeField] GameObject _ringTossTicketPrefab;
        [SerializeField] Transform _ringTossTicketSpawnPoint;
        [SerializeField] bool _hasSpawnRingTossTicket;

        RingTossBoothService _ringTossBoothService;
        
        public static PrizeManager Instance { get; private set; }
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        void OnDisable()
        {
            _ringTossBoothService.OnScoreChanged -= HandleRingTossScoreChange;
        }

        void HandleRingTossScoreChange(int newScore)
        {
            if (_hasSpawnRingTossTicket) return;
            
            if (newScore >= _ringTossPrizeScore)
            {
                var ringPrize = Instantiate(_ringTossTicketPrefab, _ringTossTicketSpawnPoint.position,
                    _ringTossTicketSpawnPoint.rotation);

                _hasSpawnRingTossTicket = true;
            }
        }

        public void SetRingToss(RingTossBoothService ringTossBoothService)
        {
            _ringTossBoothService = ringTossBoothService;
            _ringTossBoothService.OnScoreChanged += HandleRingTossScoreChange;
        }
    }
}