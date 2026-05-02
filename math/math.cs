using System;

namespace include.math {
  public static class h {
    public static float min(float a, float b) => (a < b) ? a : b;
    public static int min(int a, int b) => (a < b) ? a : b;

    public static float max(float a, float b) => (a > b) ? a : b;
    public static int max(int a, int b) => (a > b) ? a : b;

    public static float pow(float t, float p) => (float)Math.Pow(t, p);
    public static float round(float a) => (float)Math.Round(a);
    public static int rtoi(float a) => (int)Math.Round(a);

    public static float sin(float v) => (float)Math.Sin(v);
    public static float cos(float v) => (float)Math.Cos(v);

    public static int ftoi(float v) => (int)Math.Floor(v);

    public static float step(float edge, float x) => x < edge ? 0f : 1f;

    public static float lerp(float a, float b, float t) => a + (b - a) * clamp01(t);

    public static float inv_lerp(float a, float b, float value) {
      return (a != b) ? clamp01((value - a) / (b - a)) : 0f;
    }
    public static float sqrt(float v) => (float)Math.Sqrt(v);
    public static float abs(float f) => Math.Abs(f);
    public static float clamp01(float v) {
    if (v < 0f) {
      return 0f;
    }
    if (v > 1f) {
        return 1f;
      }
      return v;
    }
    public static float clamp(float v, float min_v, float max_v) {
      if (v < min_v) {
        v = min_v;
      }
      else if (v > max_v) {
        v = max_v;
      }

      return v;
    }
  }
}