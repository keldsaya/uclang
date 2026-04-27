using UnityEngine;

namespace include.time {
  public static class h {
    public static float time_val => Time.time;
    public static float time_delta => Time.deltaTime;
    public static float @time_fixed => Time.fixedTime;
    public static float time_fixed_delta {
      get => Time.fixedDeltaTime;
      set => Time.fixedDeltaTime = value;
    }
    public static float time_unscaled => Time.unscaledTime;
    public static float time_unscale_delta => Time.unscaledDeltaTime;
    public static float time_scale {
      get => Time.timeScale;
      set => Time.timeScale = value;
    }
  }
}