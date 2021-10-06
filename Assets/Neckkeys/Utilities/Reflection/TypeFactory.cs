using Neckkeys.Utilities.StringServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Neckkeys.Utilities.Reflection
{
    public static class TypeFactory<T>
    {
        static Dictionary<string, Type> typeByName = null;

        static void Init()
        {
            if (typeByName != null)
                return;

            IEnumerable<Type> types = Assembly.GetAssembly(typeof(T)).GetTypes().Where(
                myType => myType.IsClass &&
                myType.IsAbstract == false &&
                myType.IsSubclassOf(typeof(T)));

            typeByName = new Dictionary<string, Type>();

            foreach (Type t in types)
            {
                //MeshGeneratorMono o = Activator.CreateInstance(t) as MeshGeneratorMono;
                typeByName.Add(t.FullName, t);
            }
        }

        public static Type GetType(string fullName)
        {
            Init();

            if (typeByName.ContainsKey(fullName) == false)
            {
                Debug.LogError(StringConsts.Reflection.TypeNotFound);
                return null;
            }

            return typeByName[fullName];
        }

        public static IEnumerable<string> GetTypeNames()
        {
            Init();
            return typeByName.Keys;
        }
    }
}