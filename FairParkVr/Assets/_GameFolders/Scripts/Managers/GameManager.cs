using UnityEngine;

namespace FairParkVr.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int _targetFrame;
        [SerializeField] GameState _gameState;

        public static GameManager Instance { get; private set; }
        public event System.Action<GameState> OnGameStateChanged;

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

            Application.targetFrameRate = _targetFrame;
        }

        public void UpdateGameState(GameState gameState)
        {
            if (_gameState == gameState) return;

            _gameState = gameState;

            OnGameStateChanged?.Invoke(_gameState);

            if (_gameState == GameState.Quit)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }
    }

    public enum GameState
    {
        Start,
        Play,
        Pause,
        Quit,
        NotSelected
    }
}