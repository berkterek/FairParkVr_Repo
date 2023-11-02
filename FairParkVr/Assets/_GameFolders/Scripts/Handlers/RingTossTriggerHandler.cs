using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FairParkVr.Handlers
{
    public class RingTossTriggerHandler : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bottle"))
            {
                
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Bottle"))
            {
                
            }
        }

        async UniTask ScoreDelayAsync()
        {
            
        }
    }
}