using UnityEngine;
namespace include.app_h {
  public static class app {
    public static bool is_playing => Application.isPlaying;
    public static bool is_focus => Application.isFocused;
    public static bool is_batch => Application.isBatchMode;
    public static string data => Application.dataPath;
    public static string steam_assets => Application.streamingAssetsPath;
    public static string persis_data => Application.persistentDataPath;
    public static string unity_ver => Application.unityVersion;
    public static string ver => Application.version;
  }
}