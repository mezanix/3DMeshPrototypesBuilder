using System;
using UnityEngine;

namespace Neckkeys.Utilities.Math
{
    [Serializable]
    public class TransformParams
    {
        public Vector3 position = Vector3.zero;
        public Vector3 rotation = Vector3.zero;
        public Vector3 scale = Vector3.one;
    }
}