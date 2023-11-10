using FairParkVr.Managers;
using UnityEngine;

namespace FairParkVr.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject _continuesMoveObject;

        void Start()
        {
            _continuesMoveObject.SetActive(false);
        }

        void OnEnable()
        {
            GameManager.Instance.OnGameStateChanged += HandleOnGameStateChanged;
        }

        void OnDisable()
        {
            GameManager.Instance.OnGameStateChanged += HandleOnGameStateChanged;
        }
        
        void HandleOnGameStateChanged(GameState gameState)
        {
            if (gameState == GameState.Start || gameState == GameState.Play)
            {
                _continuesMoveObject.SetActive(true);
            }
            else
            {
                _continuesMoveObject.SetActive(false);
            }
        }
    }
}