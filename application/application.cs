using UnityEngine;
namespace include.app {
  public static class h {
    public static bool app_is_playing => Application.isPlaying;
    public static bool app_is_focus => Application.isFocused;
    public static bool app_is_batch => Application.isBatchMode;
    public static string app_data => Application.dataPath;
    public static string app_steam_assets => Application.streamingAssetsPath;
    public static string app_persis_data => Application.persistentDataPath;
    public static string app_unity_ver => Application.unityVersion;
    public static string app_ver => Application.version;
  }
}