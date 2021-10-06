using UnityEngine;

namespace Neckkeys.Utilities.MeshUtililties
{
    public class MeshDebugerMono : MonoBehaviour
    {
        MeshDebuger debuger = null;

        void Start()
        {
            debuger = new MeshDebuger(
                GetComponent<MeshFilter>().mesh, transform, 1f, Color.cyan);
        }

        void Update()
        {
            debuger.Run();
        }
    }
}