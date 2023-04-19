using System.Collections.Generic;

namespace vibrance.GUI.common
{
    public interface IVibranceProxy
    {
        GraphicsAdapter GraphicsAdapter { get; }
        void SetApplicationSettings(List<ApplicationSetting> refApplicationSettings);
        void SetShouldRun(bool shouldRun);
        void SetVibranceWindowsLevel(int vibranceWindowsLevel);
        void SetVibranceIngameLevel(int vibranceIngameLevel);
        bool UnloadLibraryEx();
        void HandleDvcExit();
        void SetAffectPrimaryMonitorOnly(bool affectPrimaryMonitorOnly);
        VibranceInfo GetVibranceInfo();
        void SetNeverSwitchResolution(bool neverSwitchResolution);
    }
}
