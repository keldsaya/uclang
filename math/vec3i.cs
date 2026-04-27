using System;
using System.Globalization;
using UnityEngine;

namespace include.math {
  [Serializable]
  public struct vec3i : IEquatable<vec3i>, IFormattable {
    public int x, y, z;

    public static readonly vec3i zero    = new vec3i(0, 0, 0);
    public static readonly vec3i one     = new vec3i(1, 1, 1);
    public static readonly vec3i up      = new vec3i(0, 1, 0);
    public static readonly vec3i down    = new vec3i(0, -1, 0);
    public static readonly vec3i left    = new vec3i(-1, 0, 0);
    public static readonly vec3i right   = new vec3i(1, 0, 0);
    public static readonly vec3i forward = new vec3i(0, 0, 1);
    public static readonly vec3i back    = new vec3i(0, 0, -1);

    public vec3i(int x, int y, int z) { this.x = x; this.y = y; this.z = z; }

    public static vec3i operator +(vec3i a, vec3i b) => new vec3i(a.x + b.x, a.y + b.y, a.z + b.z);
    public static vec3i operator -(vec3i a, vec3i b) => new vec3i(a.x - b.x, a.y - b.y, a.z - b.z);
    public static vec3i operator -(vec3i a) => new vec3i(-a.x, -a.y, -a.z);
    public static vec3i operator *(vec3i a, int b) => new vec3i(a.x * b, a.y * b, a.z * b);
    public static vec3i operator *(int a, vec3i b) => new vec3i(a * b.x, a * b.y, a * b.z);
    public static vec3i operator /(vec3i a, int b) => new vec3i(a.x / b, a.y / b, a.z / b);

    public static bool operator ==(vec3i a, vec3i b) => a.x == b.x && a.y == b.y && a.z == b.z;
    public static bool operator !=(vec3i a, vec3i b) => !(a == b);

    public override bool Equals(object obj) => obj is vec3i other && Equals(other);
    public bool Equals(vec3i other) => x == other.x && y == other.y && z == other.z;
    public override int GetHashCode() => HashCode.Combine(x, y, z);
    public override string ToString() => ToString(null, null);
    public string ToString(string format, IFormatProvider formatProvider = null) => 
      $"({x.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)}, {y.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)}, {z.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)})";

    public static implicit operator Vector3Int(vec3i v) => new Vector3Int(v.x, v.y, v.z);
    public static implicit operator vec3i(Vector3Int v) => new vec3i(v.x, v.y, v.z);
  }
}