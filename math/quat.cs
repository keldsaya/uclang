using System;
using System.Globalization;
using UnityEngine;
namespace include.math {
  [Serializable]
  public struct quat : IEquatable<quat>, IFormattable {
    public float x, y, z, w;
    public static readonly quat identity = new quat(0, 0, 0, 1);

    public quat(float x, float y, float z, float w) { this.x = x; this.y = y; this.z = z; this.w = w; }
    public vec3 euler_angles => (vec3)((Quaternion)this).eulerAngles;

    public static quat euler(float x, float y, float z) => (quat)Quaternion.Euler(x, y, z);
    public static quat euler(vec3 v) => (quat)Quaternion.Euler(v);
    public static quat look_rotation(vec3 forward, vec3 up) => (quat)Quaternion.LookRotation(forward, up);
    public static quat angle_axis(float angle, vec3 axis) => (quat)Quaternion.AngleAxis(angle, axis);
    public static quat inverse(quat q) => (quat)Quaternion.Inverse(q);
    public static quat lerp(quat a, quat b, float t) => (quat)Quaternion.Lerp(a, b, t);
    public static quat slerp(quat a, quat b, float t) => (quat)Quaternion.Slerp(a, b, t);

    public static quat operator *(quat a, quat b) => (quat)((Quaternion)a * (Quaternion)b);
    public static vec3 operator *(quat q, vec3 v) => (vec3)((Quaternion)q * (Vector3)v);
    public static bool operator ==(quat a, quat b) => Mathf.Abs(a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w) > 0.999999f;
    public static bool operator !=(quat a, quat b) => !(a == b);

    public override bool Equals(object obj) => obj is quat other && Equals(other);
    public bool Equals(quat other) => this == other;
    public override int GetHashCode() => HashCode.Combine(x, y, z, w);
    public string ToString(string format, IFormatProvider formatProvider = null) => 
      $"({x.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)}, {y.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)}, {z.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)}, {w.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)})";

    public static implicit operator Quaternion(quat q) => new Quaternion(q.x, q.y, q.z, q.w);
    public static implicit operator quat(Quaternion q) => new quat(q.x, q.y, q.z, q.w);
  }
}