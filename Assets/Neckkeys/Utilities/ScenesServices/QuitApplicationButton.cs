using Neckkeys.Abstract.StringServices;
using Neckkeys.Utilities.StringServices;
using UnityEngine;
using UnityEngine.UI;

namespace Neckkeys.Utilities.UI
{
    [AddComponentMenu("Neckkeys/Quit Application Button")]
    public class QuitApplicationButton : UnityUIButton
    {
        ILogMessages logMessages = null;
        ILogMessages LogMessages
        {
            get { if (logMessages == null) logMessages = new LogMessages("Quit Application Button"); return logMessages; }
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

            Application.Quit();
        }
    }
}