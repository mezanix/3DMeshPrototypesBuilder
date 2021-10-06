using UnityEngine;

namespace Neckkeys.Utilities.Sensors
{
    public class SensorTrigger2D : MonoBehaviour
    {
        bool detected = false;
        public bool Detected => detected;
                
        bool isDetectedIsTrigger = false; 
        public bool IsDetectedIsTrigger { get => isDetectedIsTrigger; }


        public void Init()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            detected = true;
            isDetectedIsTrigger = collision.isTrigger;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            detected = true;
            isDetectedIsTrigger = collision.isTrigger;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            detected = false;
        }
    }
}