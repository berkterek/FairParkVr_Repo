using UnityEngine;

namespace FairParkVr.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int _targetFrame;
        
        void Awake()
        {
            Application.targetFrameRate = _targetFrame;
        }
    }    
}