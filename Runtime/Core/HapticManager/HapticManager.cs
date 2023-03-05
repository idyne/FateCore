using Lofelt.NiceVibrations;
namespace FateGames
{
    public static class HapticManager
    {
        public static void PlayHaptic(HapticPatterns.PresetType presetType = HapticPatterns.PresetType.LightImpact)
        {
            HapticPatterns.PlayPreset(presetType);
        }

    }
}