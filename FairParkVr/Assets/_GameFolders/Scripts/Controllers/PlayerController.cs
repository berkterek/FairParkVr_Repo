using Cysharp.Threading.Tasks;
using FairParkVr.Managers;
using UnityEngine;

namespace FairParkVr.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject _continuesMoveObject;
        [SerializeField] GameObject[] _hands;

        async void Start()
        {
            _continuesMoveObject.SetActive(false);

            await UniTask.Delay(2000);

            foreach (var hand in _hands)
            {
                hand.SetActive(true);
            }
        }

        async void OnEnable()
        {
            await UniTask.WaitUntil(() => GameManager.Instance != null);
            
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