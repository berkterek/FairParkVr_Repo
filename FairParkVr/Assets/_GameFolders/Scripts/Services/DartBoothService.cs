using UnityEngine;

namespace FairParkVr.Services
{
    public class DartBoothService : MonoBehaviour
    {
        [SerializeField] GameObject[] _balloons;

        int _balloonsPopped;
        float _timer = 0f;
        bool _isTimerRunning;

        public event System.Action<float> OnTimerValueChanged;

        void Update()
        {
            if (!_isTimerRunning) return;
            
            _timer += Time.deltaTime;
            OnTimerValueChanged?.Invoke(_timer);
        }

        public void PopBalloon()
        {
            _balloonsPopped++;
            if (_balloonsPopped == _balloons.Length)
            {
                PauseGame();
            }
        }

        public void StartGame()
        {
            _isTimerRunning = true;
        }

        public void PauseGame()
        {
            _isTimerRunning = false;
        }

        public void ResetGame()
        {
            _balloonsPopped = 0;
            _timer = 0f;

            foreach (var balloon in _balloons)
            {
                balloon.SetActive(true);
            }
        }
    }
}