using System;
using Cysharp.Threading.Tasks;
using FairParkVr.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FairParkVr.Uis
{
    public class DartPresenter : MonoBehaviour
    {
        const string CONST_MESSAGE_VALUE = "Timer:";
        
        [SerializeField] TMP_Text _scoreText;
        [SerializeField] Button _resetButton;

        DartBoothService _dartBoothService;
        
        async void Start()
        {
            while (_dartBoothService == null)
            {
                _dartBoothService = FindObjectOfType<DartBoothService>();
                await UniTask.Yield();
            }

            _dartBoothService.OnTimerValueChanged += HandleOnScoreChanged;
            _resetButton.onClick.AddListener(HandleOnButtonClicked);
        }

        void OnDisable()
        {
            if (_dartBoothService == null) return;
            
            _dartBoothService.OnTimerValueChanged -= HandleOnScoreChanged;
            _resetButton.onClick.RemoveListener(HandleOnButtonClicked);
        }

        void HandleOnScoreChanged(float value)
        {
            _scoreText.SetText($"{CONST_MESSAGE_VALUE} {value:0}");
        }

        void HandleOnButtonClicked()
        {
            _dartBoothService.ResetGame();
        }
    }
}