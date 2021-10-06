using Neckkeys.Abstract.ScenesServices;
using UnityEngine.SceneManagement;

namespace Neckkeys.Utilities.ScenesServices
{
    public class ScenesLoadingServices : IScenesLoadingServices
    {
        Scene GetActiveScene()
        {
            return SceneManager.GetActiveScene();
        }

        string IScenesLoadingServices.GetActiveSceneName()
        {
            return GetActiveScene().name;
        }

        void IScenesLoadingServices.LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        void IScenesLoadingServices.ReloadTheSameScene()
        {
            SceneManager.LoadScene(GetActiveScene().name);
        }
    }
}