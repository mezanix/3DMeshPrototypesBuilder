using UnityEngine;

namespace Neckkeys.Abstract.UnityStaticServices
{
    public interface IUnityInputService
    {
        bool GetKeyDown(KeyCode keyCode);
        bool GetKeyDownIgnoreGameIsOnPause(KeyCode keyCode);

        float GetAxis(string axisName);

        bool GetPlatformerJumpInputDeviceAdaptive();

        float GetPlatformerMoveHorizontalDeviceAdaptive();

        void SetGameIsOnPause(bool v);
        bool GetGameIsOnPause();

        bool SwitchGameIsOnPause();
    }
}