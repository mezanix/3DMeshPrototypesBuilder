using System;
using UnityEngine;

namespace Neckkeys.Utilities.Zones
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ZoneTrigger2D : MonoBehaviour
    {
        BoxCollider2D myCollider = null;
        BoxCollider2D Collider
        {
            get
            {
                if (myCollider == null)
                    myCollider = GetComponent<BoxCollider2D>();
                return myCollider;
            }
        }

        private void Start()
        {
            StartFired();
        }

        protected virtual void StartFired()
        {
            Collider.isTrigger = true;

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTriggerEnter2DFired(collision);
        }

        protected virtual void OnTriggerEnter2DFired(Collider2D collision)
        {

        }
    }
}