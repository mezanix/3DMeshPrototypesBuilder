using System;
using UnityEngine;
using UnityEngine.UI;

namespace Neckkeys.Utilities.UI
{
    public class UnityUIButton : MonoBehaviour
    {
        Button button = null;
        protected Button Button
        {
            get
            {
                if (button == null)
                    button = GetComponent<Button>();
                return button;
            }
        }

        private void OnValidate()
        {
            OnValidateFired();
        }

        private void Awake()
        {
            Button.onClick.AddListener(Clicked);

            AwakeFired();
        }

        private void OnEnable()
        {
            OnEnableFired();
        }

        private void OnDisable()
        {
            OnDisableFired();
        }

        protected virtual void OnDisableFired()
        {

        }

        protected virtual void OnEnableFired()
        {

        }

        protected virtual void AwakeFired()
        {
        }

        protected virtual void OnValidateFired()
        {
        }

        protected virtual void Clicked()
        {
        }
    }
}