using Neckkeys.Abstract.UnityStaticServices;
using UnityEngine;

namespace Neckkeys.Utilities.UnityStaticServices
{
    public class UnityInputService : IUnityInputService
    {
        const string horizontal = "Horizontal";

        bool gameIsOnPause = false;

        float IUnityInputService.GetAxis(string axisName)
        {
            if (gameIsOnPause)
                return 0f;
            return Input.GetAxis(axisName);
        }

        bool IUnityInputService.GetKeyDown(KeyCode keyCode)
        {
            if (gameIsOnPause)
                return false;
            return Input.GetKeyDown(keyCode);
        }

        bool IUnityInputService.GetKeyDownIgnoreGameIsOnPause(KeyCode keyCode)
        {
            return Input.GetKeyDown(keyCode);
        }

        bool IUnityInputService.GetPlatformerJumpInputDeviceAdaptive()
        {
            if (gameIsOnPause)
                return false;

#if UNITY_STANDALONE 
            return Input.GetKeyDown(KeyCode.Space);
#endif
        }

        float IUnityInputService.GetPlatformerMoveHorizontalDeviceAdaptive()
        {
            if (gameIsOnPause)
                return 0f;

#if UNITY_STANDALONE
            return Input.GetAxis(horizontal);
#endif
        }


        #region GameIsOnPause
        bool IUnityInputService.GetGameIsOnPause()
        {
            return gameIsOnPause;
        }

        public void SetGameIsOnPause(bool v)
        {
            gameIsOnPause = v;
            Time.timeScale = gameIsOnPause ? 0f : 1f;
#if UNITY_STANDALONE
            Cursor.lockState = gameIsOnPause ? CursorLockMode.None : CursorLockMode.Locked;
#endif
        }

        bool IUnityInputService.SwitchGameIsOnPause()
        {
            SetGameIsOnPause(!gameIsOnPause);
            return gameIsOnPause;
        }

        #endregion // GameIsOnPause
    }
}