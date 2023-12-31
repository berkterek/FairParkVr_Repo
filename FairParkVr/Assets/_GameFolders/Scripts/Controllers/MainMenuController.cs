using FairParkVr.Managers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace FairParkVr.Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] GameObject _modalSingleton;
        [SerializeField] ActionBasedControllerManager _rightHandControllerManager;
        [SerializeField] Button _startButton;
        [SerializeField] Button _quitButton;
        [SerializeField] Button _turnToggleButton;
        [SerializeField] Text _turnText;
        bool _isMenuOpen;

        void Start()
        {
            _isMenuOpen = _modalSingleton.gameObject.activeSelf;
            SetToggleText();
        }

        void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _quitButton.onClick.AddListener(OnQuitButtonClicked);
            _turnToggleButton.onClick.AddListener(HandleOnToggleButtonClicked);
        }

        void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            _quitButton.onClick.RemoveListener(OnQuitButtonClicked);
            _turnToggleButton.onClick.RemoveListener(HandleOnToggleButtonClicked);
        }

        public void OnStartButtonClicked()
        {
            GameManager.Instance.UpdateGameState(GameState.Start);
            _modalSingleton.SetActive(false);
        }

        public void OnQuitButtonClicked()
        {
            GameManager.Instance.UpdateGameState(GameState.Quit);
        }

        public void OnToggleMenu()
        {
            _isMenuOpen = !_isMenuOpen;

            _modalSingleton.SetActive(_isMenuOpen);

            if (_isMenuOpen)
            {
                GameManager.Instance.UpdateGameState(GameState.Pause);
            }
            else
            {
                GameManager.Instance.UpdateGameState(GameState.Play);
            }
        }

        void HandleOnToggleButtonClicked()
        {
            _rightHandControllerManager.smoothTurnEnabled = !_rightHandControllerManager.smoothTurnEnabled;
            SetToggleText();
        }

        private void SetToggleText()
        {
            string value = _rightHandControllerManager.smoothTurnEnabled ? "On" : "Off";
            _turnText.text = "Toggle Snap Turn: " + value;
        }
    }    
}

