using UnityEngine;

namespace FairParkVr.Services
{
    public class RingTossBoothService : MonoBehaviour
    {
        [SerializeField] GameObject[] _rings;

        int _score;
        Vector3[] _ringStartPositions;
        Quaternion[] _ringStartRotations;

        public event System.Action<int> OnScoreChanged;

        void Start()
        {
            int ringsLength = _rings.Length;
            _ringStartPositions = new Vector3[ringsLength];
            _ringStartRotations = new Quaternion[ringsLength];

            for (int i = 0; i < ringsLength; i++)
            {
                _ringStartPositions[i] = _rings[i].transform.position;
                _ringStartRotations[i] = _rings[i].transform.rotation;
            }
        }

        public void AddScore()
        {
            ChangeScore(10);
        }

        [ContextMenu(nameof(ResetRingGame))]
        public void ResetRingGame()
        {
            for (int i = 0; i < _rings.Length; i++)
            {
                _rings[i].transform.SetPositionAndRotation(_ringStartPositions[i], _ringStartRotations[i]);
            }

            ChangeScore();
        }

        private void ChangeScore(int score = 0)
        {
            _score += score;
            OnScoreChanged?.Invoke(_score);
        }
    }
}