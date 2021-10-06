using Neckkeys.Utilities.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Neckkeys.MeshPrototypesBuilder
{
    public class MeshBuilder : MonoBehaviour
    {
        public string savePath = "";

        public List<GameObject> holders = new List<GameObject>();

        MeshFilter myMeshFilter = null;
        public MeshFilter MyMeshFilter
        {
            get
            {
                if (myMeshFilter == null)
                    myMeshFilter = GetComponent<MeshFilter>();
                if (myMeshFilter == null)
                    myMeshFilter = gameObject.AddComponent<MeshFilter>();
                return myMeshFilter;
            }
        }

        public void CombineMesh()
        {
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            for (int i = 0; i < meshFilters.Length; i++)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            }

            MyMeshFilter.sharedMesh = new Mesh();
            MyMeshFilter.sharedMesh.CombineMeshes(combine);
        }

        GameObject NewHolder(Type type)
        {
            transform.Reset();

            GameObject r = new GameObject(type.ToString().AfterLastOf('.'));

            r.transform.parent = transform;

            r.AddComponent(type);

            return r;
        }

        public void AddHolder(Type type)
        {
            holders.Add(NewHolder(type));
        }

        public void RepairHolders()
        {
            CleanHolders();

            //AddExtraHolders();
        }

        //private void AddExtraHolders()
        //{
        //    TriangleGenerator[] childComponents = transform.GetComponentsInChildren<TriangleGenerator>();
        //    for (int i = 0; i < childComponents.Length; i++)
        //    {
        //        if (holders.Contains(childComponents[i].gameObject))
        //            continue;

        //        holders.Add(childComponents[i].gameObject);
        //    }
        //}

        private void CleanHolders()
        {
            for (int i = holders.Count - 1; i > -1; i--)
            {
                if (holders[i] == null)
                {
                    holders.RemoveAt(i);
                }
            }
        }
    }
}