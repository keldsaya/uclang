using System;
using System.Globalization;
using UnityEngine;

namespace include.math_h {
  [Serializable]
  public struct vec2 : IEquatable<vec2>, IFormattable {
    public float x, y;

    public static readonly vec2 zero = new vec2(0, 0);
    public static readonly vec2 one = new vec2(1, 1);
    public static readonly vec2 up = new vec2(0, 1);
    public static readonly vec2 down = new vec2(0, -1);
    public static readonly vec2 left = new vec2(-1, 0);
    public static readonly vec2 right = new vec2(1, 0);

    public vec2(float x, float y) { this.x = x; this.y = y; }
    public vec2(vec2 v) { x = v.x; y = v.y; }

    public float mag() => Mathf.Sqrt(x * x + y * y);
    public float sqr_mag() => x * x + y * y;
    public vec2 normalized() {
      float m = mag();
      return m > 1e-5f ? this / m : zero;
    }

    public static float dot(vec2 a, vec2 b) => a.x * b.x + a.y * b.y;
    public static float dist(vec2 a, vec2 b) => (a - b).mag();
    public static vec2 min(vec2 a, vec2 b) => new vec2(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y));
    public static vec2 max(vec2 a, vec2 b) => new vec2(Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y));
    public static vec2 lerp(vec2 a, vec2 b, float t) => new vec2(a.x + (b.x - a.x) * Mathf.Clamp01(t), a.y + (b.y - a.y) * Mathf.Clamp01(t));
    
    public static vec2 operator +(vec2 a, vec2 b) => new vec2(a.x + b.x, a.y + b.y);
    public static vec2 operator -(vec2 a, vec2 b) => new vec2(a.x - b.x, a.y - b.y);
    public static vec2 operator *(vec2 a, float b) => new vec2(a.x * b, a.y * b);
    public static vec2 operator /(vec2 a, float b) => new vec2(a.x / b, a.y / b);
    public static bool operator ==(vec2 a, vec2 b) => (a - b).sqr_mag() < 1e-10f;
    public static bool operator !=(vec2 a, vec2 b) => !(a == b);

    public override bool Equals(object obj) => obj is vec2 other && Equals(other);
    public bool Equals(vec2 other) => x.Equals(other.x) && y.Equals(other.y);
    public override int GetHashCode() => HashCode.Combine(x, y);
    public string ToString(string format, IFormatProvider formatProvider = null) => 
      $"({x.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)}, {y.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)})";

    public static implicit operator Vector2(vec2 v) => new Vector2(v.x, v.y);
    public static implicit operator vec2(Vector2 v) => new vec2(v.x, v.y);
  }
}