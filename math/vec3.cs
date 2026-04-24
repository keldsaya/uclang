using System;
using UnityEngine;

namespace include.math_h {
  [Serializable]
  public struct vec3 : IEquatable<vec3>, IFormattable {
    public float x, y, z;

    public static readonly vec3 zero = new vec3(0, 0, 0);
    public static readonly vec3 one = new vec3(1, 1, 1);
    public static readonly vec3 up = new vec3(0, 1, 0);
    public static readonly vec3 down = new vec3(0, -1, 0);
    public static readonly vec3 left = new vec3(-1, 0, 0);
    public static readonly vec3 right = new vec3(1, 0, 0);
    public static readonly vec3 forward = new vec3(0, 0, 1);
    public static readonly vec3 back = new vec3(0, 0, -1);

    public vec3(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
    public vec3(vec2 v, float z) { this.x = v.x; this.y = v.y; this.z = z; }

    public float mag() => Mathf.Sqrt(x * x + y * y + z * z);
    public float sqr_mag() => x * x + y * y + z * z;
    public vec3 normalized() {
      float m = mag();
      return m > 1e-5f ? this / m : zero;
    }

    public static float dot(vec3 a, vec3 b) => a.x * b.x + a.y * b.y + a.z * b.z;
    public static vec3 cross(vec3 a, vec3 b) => new vec3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
    public static float dist(vec3 a, vec3 b) => (a - b).mag();
    public static vec3 lerp(vec3 a, vec3 b, float t) {
        t = math.clamp01(t);
        return new vec3(
            a.x + (b.x - a.x) * t,
            a.y + (b.y - a.y) * t,
            a.z + (b.z - a.z) * t
        );
    }
    public static vec3 lerp_unclamped(vec3 a, vec3 b, float t) {
        return new vec3(
            a.x + (b.x - a.x) * t,
            a.y + (b.y - a.y) * t,
            a.z + (b.z - a.z) * t
        );
    }

    public static vec3 operator +(vec3 a, vec3 b) => new vec3(a.x + b.x, a.y + b.y, a.z + b.z);
    public static vec3 operator -(vec3 a, vec3 b) => new vec3(a.x - b.x, a.y - b.y, a.z - b.z);
    public static vec3 operator *(vec3 a, float b) => new vec3(a.x * b, a.y * b, a.z * b);
    public static vec3 operator /(vec3 a, float b) => new vec3(a.x / b, a.y / b, a.z / b);
    public static bool operator ==(vec3 a, vec3 b) => (a - b).sqr_mag() < 1e-10f;
    public static bool operator !=(vec3 a, vec3 b) => !(a == b);

    public override bool Equals(object obj) => obj is vec3 other && Equals(other);
    public bool Equals(vec3 other) => x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
    public override int GetHashCode() => HashCode.Combine(x, y, z);
    public string ToString(string format, IFormatProvider formatProvider = null) => 
      $"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";

    public static implicit operator Vector3(vec3 v) => new Vector3(v.x, v.y, v.z);
    public static implicit operator vec3(Vector3 v) => new vec3(v.x, v.y, v.z);
  }
}