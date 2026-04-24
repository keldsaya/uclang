using UnityEngine;

namespace include.time_h {
  public static class time {
    public static float val => Time.time;
    public static float delta => Time.deltaTime;
    public static float @fixed => Time.fixedTime;
    public static float fixed_delta {
      get => Time.fixedDeltaTime;
      set => Time.fixedDeltaTime = value;
    }
    public static float unscaled => Time.unscaledTime;
    public static float unscale_delta => Time.unscaledDeltaTime;
    public static float scale {
      get => Time.timeScale;
      set => Time.timeScale = value;
    }
  }
}