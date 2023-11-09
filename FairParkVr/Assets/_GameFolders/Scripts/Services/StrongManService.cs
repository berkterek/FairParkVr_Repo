using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FairParkVr.Services
{
    public class StrongManService : MonoBehaviour
    {
        [SerializeField] float _duration = 3f;
        [SerializeField] Transform _sliderTransform;
        [SerializeField] float _sliderMaxHeight = 6.6f;

        bool _isProcessContinue = false;
        
        public void Strike(float mass, float velocity, float strikeMultiplier)
        {
            if (_isProcessContinue) return;
            
            Debug.Log($"mass:{mass} velocity:{velocity} strike multiplier:{strikeMultiplier}");

            float impactForce = mass * velocity;
            Debug.Log("Impact Force: " + impactForce);

            float sliderHeight = Mathf.Clamp(impactForce * strikeMultiplier, 0f, _sliderMaxHeight);
            
            MoveSliderAsync(sliderHeight);
        }

        private async void MoveSliderAsync(float sliderHeight)
        {
            _isProcessContinue = true;
            Vector3 target = new Vector3(0, sliderHeight, 0f);
            float timer = 0f;

            while (_sliderTransform.localPosition.y < sliderHeight)
            {
                timer += Time.deltaTime;
                _sliderTransform.localPosition =
                    Vector3.Lerp(_sliderTransform.localPosition, target, timer / _duration);
                await UniTask.Yield();
            }

            await UniTask.Delay(500);

            target = Vector3.zero;
            timer = 0f;

            while (_sliderTransform.localPosition.y > target.y)
            {
                timer += Time.deltaTime;
                _sliderTransform.localPosition =
                    Vector3.Lerp(_sliderTransform.localPosition, target, timer / _duration);
                await UniTask.Yield();
            }

            _isProcessContinue = false;
        }
    }
}