using Neckkeys.Abstract.ScenesServices;
using Neckkeys.Abstract.StringServices;
using Neckkeys.Utilities.ScenesServices;
using Neckkeys.Utilities.StringServices;
using UnityEngine;
using UnityEngine.UI;

namespace Neckkeys.Utilities.UI
{
    [AddComponentMenu("Neckkeys/Load Scene Button")]
    public class LoadSceneButton : UnityUIButton
    {
        [SerializeField] string sceneName = "Next Scene";

        IScenesLoadingServices scenesLoadingServices = new ScenesLoadingServices();

        ILogMessages logMessages = null;
        ILogMessages LogMessages
        {
            get { if (logMessages == null) logMessages = new LogMessages("Load Scene Button"); return logMessages; }
        }

        protected override void OnValidateFired()
        {
            base.OnValidateFired();

            if (GetComponent<Button>() == null)
                Debug.LogWarning(LogMessages.NeedToHaveComponentMessage("Button"));
        }

        protected override void Clicked()
        {
            base.Clicked();

            scenesLoadingServices.LoadScene(sceneName);
        }
    }
}