namespace Neckkeys.Abstract.ScenesServices
{
    public interface IScenesLoadingServices
    {
        void LoadScene(string sceneName);
        void ReloadTheSameScene();

        string GetActiveSceneName();
    }
}