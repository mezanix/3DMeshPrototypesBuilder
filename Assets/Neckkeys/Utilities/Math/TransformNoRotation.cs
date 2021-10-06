using System;
using UnityEngine;

namespace Neckkeys.Utilities.Math
{
    [Serializable]
    public class TransformNoRotation
    {
        public Vector3 position = Vector3.zero;
        public Vector3 scale = Vector3.one;
        public TransformNoRotation()
        {
        }

        public TransformNoRotation(Vector3 position)
        {
            this.position = position;
        }
    }
}