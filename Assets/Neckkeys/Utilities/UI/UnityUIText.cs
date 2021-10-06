using UnityEngine;
using UnityEngine.UI;

namespace Neckkeys.Utilities.UI
{
    public class UnityUIText : MonoBehaviour
    {
        Text text = null;
        protected Text Text
        {
            get
            {
                if (text == null)
                    text = GetComponent<Text>();
                return text;
            }
        }
        private void OnValidate()
        {
            OnValidateFired();
        }

        protected virtual void OnValidateFired()
        {
        }

        private void Start()
        {
            StartFired();
        }

        protected virtual void StartFired()
        {
        }

        private void OnDestroy()
        {
            OnDestroyFired();
        }

        protected virtual void OnDestroyFired()
        {

        }
    }
}