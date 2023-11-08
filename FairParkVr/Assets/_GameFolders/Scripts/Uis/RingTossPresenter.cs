using Cysharp.Threading.Tasks;
using FairParkVr.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FairParkVr.Uis
{
    public class RingTossPresenter : MonoBehaviour
    {
        const string CONST_MESSAGE_VALUE = "Score:";
        
        [SerializeField] TMP_Text _scoreText;
        [SerializeField] Button _resetButton;

        RingTossBoothService _ringTossBoothService; 

        async void Start()
        {
            while (_ringTossBoothService == null)
            {
                _ringTossBoothService = FindObjectOfType<RingTossBoothService>();
                await UniTask.Yield();
            }

            _ringTossBoothService.OnScoreChanged += HandleOnScoreChanged;
            _resetButton.onClick.AddListener(HandleOnButtonClicked);
        }

        void OnDisable()
        {
            if (_ringTossBoothService == null) return;
            
            _ringTossBoothService.OnScoreChanged -= HandleOnScoreChanged;
            _resetButton.onClick.RemoveListener(HandleOnButtonClicked);
        }
        
        void HandleOnScoreChanged(int score)
        {
            _scoreText.SetText($"{CONST_MESSAGE_VALUE} {score}");
        }
        
        void HandleOnButtonClicked()
        {
            _ringTossBoothService.ResetRingGame();
        }
    }    
}

