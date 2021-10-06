using Neckkeys.Abstract.DataServices;
using System;
using UnityEngine;

namespace Neckkeys.Utilities.DataServices
{
    [Serializable]
    public class LabeledSavableInt : ILabeledInt, ISavableInt
    {
        [SerializeField] string label = "My Int";
        [SerializeField] int value = 0;

        public void Increment(int by)
        {
            value += by;
        }

        public void SetValue(int v)
        {
            value = v;
        }

        public string GetLabel()
        {
            return label;
        }

        public int GetValue()
        {
            return value;
        }

        public void Load(string key)
        {
            value = PlayerPrefs.GetInt(key, 0);
        }

        public void Save(string key)
        {
            PlayerPrefs.SetInt(key, value);
        }
    }
}